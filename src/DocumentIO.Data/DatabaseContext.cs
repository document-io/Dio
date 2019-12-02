using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options)
			: base(options)
		{
		}

		public DbSet<Organization> Organizations { get; set; }
		public DbSet<Invite> Invites { get; set; }
		public DbSet<Account> Accounts { get; set; }

		public DbSet<Board> Boards { get; set; }
		public DbSet<Column> Columns { get; set; }
		public DbSet<Card> Cards { get; set; }

		public DbSet<Label> Labels { get; set; }
		public DbSet<CardLabel> CardLabels { get; set; }

		public DbSet<CardAssignment> CardAssignments { get; set; }
		public DbSet<CardComment> CardComments { get; set; }
		public DbSet<CardAttachment> CardAttachments { get; set; }
		public DbSet<CardEvent> CardEvents { get; set; }

		public DbSet<File> Files { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// TODO: EntityConfigurations
			modelBuilder.Entity<CardLabel>()
				.HasKey(cardLabel => new {cardLabel.CardId, cardLabel.LabelId});

			modelBuilder.Entity<CardAssignment>()
				.HasKey(cardAssignment => new {cardAssignment.AccountId, cardAssignment.CardId});
		}
	}
}