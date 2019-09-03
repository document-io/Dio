using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dio.Web
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
			services.AddDatabaseContext(configuration.GetConnectionString("postgresql"));

			services.AddAuthorization()
				.AddDioAuthentication()
				.AddControllers();

			services.AddDioSpa()
				.AddDioSwagger();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
		{
			app.UseHttpsRedirection();

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseDioSwagger();
			app.UseEndpoints(endpoints => endpoints.MapControllers());

			app.UseDioSpa(environment);
		}
	}
}