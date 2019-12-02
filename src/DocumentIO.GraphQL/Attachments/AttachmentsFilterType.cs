namespace DocumentIO
{
	public class AttachmentsFilterType : DocumentIOFilterType<CardAttachment, AttachmentsFilter>
	{
		public AttachmentsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Name);
			NullField(x => x.FileName);
			NullField(x => x.ContentType);
			NullField(x => x.ContentDisposition);
			NullField(x => x.Length);
			NullField(x => x.CardId);
		}
	}
}