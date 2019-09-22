namespace DocumentIO
{
	public class ReadAttachmentType : DocumentIOGraphType<CardAttachment>
	{
		public ReadAttachmentType()
		{
			Field(x => x.Id);
			Field(x => x.MimeType);
			Field(x => x.Content);
			Field(x => x.CreatedAt);

			NonNullDocumentIOField<ReadCardType, Card>("card")
				.Authorize(Roles.User)
				.ResolveAsync<AttachmentCardResolver>();

			NonNullDocumentIOField<ReadAccountType, Account>("account")
				.Authorize(Roles.User)
				.ResolveAsync<AttachmentAccountResolver>();
		}
	}
}