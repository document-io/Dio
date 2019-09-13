using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DocumentIO.Web
{
	public static class MigrationExtensions
	{
		public static void UseDocumentIOMigrations(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var connectionString  = scope.ServiceProvider.GetRequiredService<IConfiguration>()
					.GetConnectionString("PostgreSQL");

				scope.ServiceProvider.GetRequiredService<ILogger<DatabaseContext>>()
					.LogError("CONNECTIONSTRING: " + connectionString);
				
				var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

				databaseContext.Database.Migrate();
			}
		}
	}
}