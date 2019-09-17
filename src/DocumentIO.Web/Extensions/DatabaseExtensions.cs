using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO
{
	public static class DatabaseExtensions
	{
		public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
		{
			return services.AddDbContext<DatabaseContext>(options =>
				options.UseNpgsql(connectionString, builder =>
					builder.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
		}

		public static void UseDatabaseMigrations(this IApplicationBuilder app)
		{
			using (var scope = app.ApplicationServices.CreateScope())
			{
				var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();

				databaseContext.Database.Migrate();
			}
		}
	}
}