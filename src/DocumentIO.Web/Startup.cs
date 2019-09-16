using System;
using System.Threading.Tasks;
using GraphQL.Server.Ui.Voyager;
using GraphQL.Types;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
			services.AddDatabaseContext();

			services.AddDocumentIOGraphQL();
			services.AddDocumentIOGraphQLAuthorization();

			services.AddControllers();

			services.AddAuthorization()
				.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Events.OnRedirectToLogin = context =>
					{
						context.Response.StatusCode = 401;
						return Task.CompletedTask;
					};

					options.Cookie.HttpOnly = true;
					options.SlidingExpiration = true;
					options.ExpireTimeSpan = TimeSpan.FromDays(7);
				});

			services.AddSpaStaticFiles(options =>
			{
				options.RootPath = configuration.GetValue<string>("Spa:RootPath");
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{
			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseGraphQL<ISchema>();
			app.UseGraphiQLServer();
			app.UseGraphQLVoyager();

			app.UseEndpoints(e => e.MapControllers());

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