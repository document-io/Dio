namespace DocumentIO
{
	public class DocumentVersionReview
	{
		public int Id { get; set; }

		public string Comment { get; set; }

		public int ReviewerId { get; set; }
		public Employee Reviewer { get; set; }

		public int VersionId { get; set; }
		public DocumentVersion Version { get; set; }
	}
}