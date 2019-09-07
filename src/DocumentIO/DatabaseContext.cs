using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
		{
		}

		public DbSet<Employee> Employees { get; set; }
		public DbSet<Document> Documents { get; set; }
		public DbSet<DocumentCategory> Categories { get; set; }
		public DbSet<DocumentVersion> Versions { get; set; }
		public DbSet<DocumentAssignment> Assignments { get; set; }
		public DbSet<DocumentVersionContent> VersionContents { get; set; }
		public DbSet<DocumentVersionReview> VersionReviews { get; set; }
	}
}