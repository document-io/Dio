namespace DocumentIO
{
	public class AttachmentFilterType : DocumentIOFilterType<CardAttachment, AttachmentFilter>
	{
		public AttachmentFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.MimeType);
		}
	}
}