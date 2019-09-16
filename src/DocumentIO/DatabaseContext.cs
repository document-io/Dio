using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}
		
		public DbSet<Account> Accounts { get; set; }
	}
}