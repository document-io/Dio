namespace DocumentIO
{
	public class AttachmentFilterType : FilterType<CardAttachment, AttachmentFilter>
	{
		public AttachmentFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.MimeType, nullable: true);
		}
	}
}