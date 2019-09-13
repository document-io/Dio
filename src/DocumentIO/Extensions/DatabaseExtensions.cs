using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO
{
	public static class DatabaseExtensions
	{
		public static IServiceCollection AddDatabaseContext(this IServiceCollection services, string connectionString)
		{
			Console.WriteLine("CONNECTIONSTRING");
			Console.WriteLine(connectionString);
			Console.WriteLine("CONNECTIONSTRING");

			return services.AddDbContext<DatabaseContext>(options =>
				options.UseNpgsql(connectionString));
		}
	}
}