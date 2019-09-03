using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Dio.Web
{
	public static class SwaggerExtensions
	{
		public static IServiceCollection AddDioSwagger(this IServiceCollection services)
		{
			return services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "DIO Api v1", Version = "v1" });
			});
		}

		public static void UseDioSwagger(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(options =>
			{
				options.SwaggerEndpoint("/swagger/v1/swagger.json", "DIO Api v1");
			});
		}
	}
}