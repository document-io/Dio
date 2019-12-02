using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Phema.Validation;

namespace DocumentIO.Web
{
	public class Startup
	{
		private readonly IConfiguration configuration;
		private readonly IWebHostEnvironment environment;

		public Startup(IConfiguration configuration, IWebHostEnvironment environment)
		{
			this.environment = environment;
			this.configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDatabaseContext(configuration.GetConnectionString("PostgreSQL"));

			services.AddDocumentIOGraphQL(environment);
			services.AddDocumentIOGraphQLAuthorization();

			services.AddAuthorization()
				.AddDocumentIOAuthentication()
				.AddSingleton<IPasswordHasher<Account>, PasswordHasher<Account>>();

			services.AddValidation(options =>
				options.ValidationPartResolver = ValidationPartResolvers.CamelCase);

			services.AddControllers();

			services.AddSpaStaticFiles(options =>
			{
				options.RootPath = configuration.GetValue<string>("Spa:RootPath");
			});
		}

		public void Configure(IApplicationBuilder app)
		{
			app.UseDatabaseMigrations();

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseGraphQL<ISchema>();
			app.UseGraphiQLServer();
			app.UseGraphQLVoyager();

			app.UseEndpoints(builder =>
			{
				builder.MapControllers();
			});

			app.UseSpaStaticFiles();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = configuration.GetValue<string>("Spa:SourcePath");

				if (environment.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(configuration.GetValue<string>("Spa:NpmScript"));
				}
			});
		}
	}
}