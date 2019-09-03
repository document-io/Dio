using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocumentIO.Web
{
	public static class SpaExtensions
	{
		public static IServiceCollection AddDioSpa(this IServiceCollection services)
		{
			services.AddSpaStaticFiles(configuration =>
			{
				configuration.RootPath = "DocumentIO/build";
			});

			return services;
		}

		public static void UseDioSpa(this IApplicationBuilder app, IWebHostEnvironment environment)
		{
			app.UseSpaStaticFiles();
			app.UseSpa(spa =>
			{
				spa.Options.SourcePath = "DocumentIO";

				if (environment.IsDevelopment())
				{
					spa.UseReactDevelopmentServer(npmScript: "start");
				}
			});
		}
	}
}