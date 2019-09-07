namespace DocumentIO
{
	public class DocumentVersionContent
	{
		public int Id { get; set; }
		public byte[] Content { get; set; }
		public string FileExtension { get; set; }

		public int VersionId { get; set; }
		public DocumentVersion Version { get; set; }
	}
}