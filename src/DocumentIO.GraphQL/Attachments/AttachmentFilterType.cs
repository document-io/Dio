namespace DocumentIO
{
	public class AttachmentFilterType : DocumentIOFilterType<CardAttachment, AttachmentFilter>
	{
		public AttachmentFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.MimeType, nullable: true);
		}
	}
}