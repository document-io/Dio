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
		public DbSet<Organization> Organizations { get; set; }
		public DbSet<Invite> Invites { get; set; }
	}
}