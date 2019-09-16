using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO
{
	public static class DatabaseExtensions
	{
		public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
		{
			return services.AddDbContext<DatabaseContext>(options =>
				options.UseInMemoryDatabase(nameof(DatabaseContext)));

//			return services.AddDbContext<DatabaseContext>(options =>
//				options.UseNpgsql(connectionString, builder =>
//					builder.MigrationsAssembly(typeof(DatabaseContext).Assembly.FullName)));
		}
	}
}