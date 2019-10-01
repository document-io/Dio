namespace DocumentIO
{
	public class AttachmentsFilterType : DocumentIOFilterType<CardAttachment, AttachmentsFilter>
	{
		public AttachmentsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.MimeType);
		}
	}
}