namespace DocumentIO
{
	public class ReadAttachmentType : DocumentIOGraphType<CardAttachment>
	{
		public ReadAttachmentType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			NullField(x => x.FileName);
			NullField(x => x.ContentType);
			NullField(x => x.ContentDisposition);
			NullField(x => x.Length);
			Field(x => x.CreatedAt);

			NonNullDocumentIOField<ReadCardType, Card>("card")
				.AllowUser()
				.ResolveAsync<AttachmentCardResolver>();

			NonNullDocumentIOField<ReadAccountType, Account>("account")
				.AllowUser()
				.ResolveAsync<AttachmentAccountResolver>();
		}
	}
}