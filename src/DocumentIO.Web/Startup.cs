using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Phema.Validation;

namespace DocumentIO.Web
{
	public class Startup
	{
		private readonly IConfiguration configuration;

		public Startup(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDatabaseContext(configuration.GetConnectionString("PostgreSQL"));

			services.AddAuthorization()
				.AddDocumentIOAuthentication();

			services.AddValidation(options => options.ValidationPartResolver = ValidationPartResolvers.CamelCase);

			services.AddControllers()
				.AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);

			services.AddDocumentIOSwagger()
				.AddDocumentIOSpa();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{
			app.UseDocumentIOMigrations();

			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseDocumentIOSwagger();
			app.UseEndpoints(endpoints => endpoints.MapControllers());

			app.UseDocumentIOSpa(environment);
		}
	}
}