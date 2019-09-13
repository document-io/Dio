using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO.Web
{
	public static class MigrationExtensions
	{
		public static void UseDocumentIOMigrations(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

				databaseContext.Database.Migrate();
			}
		}
	}
}