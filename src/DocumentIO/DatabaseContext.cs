using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<Company> Companies { get; set; }
		public DbSet<Invite> Invites { get; set; }
		public DbSet<Account> Accounts { get; set; }
	}
}