using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO.Web
{
	public static class SpaExtensions
	{
		public static IServiceCollection AddDocumentIOSpa(this IServiceCollection services)
		{
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "frontend";
			});

			return services;
		}

		public static void UseDocumentIOSpa(this IApplicationBuilder app, IWebHostEnvironment environment)
		{
			app.UseSpaStaticFiles();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "../DocumentIO.Frontend";

				if (environment.IsDevelopment())
				{
					spa.UseReactDevelopmentServer("dev");
				}
			});
		}
	}
}