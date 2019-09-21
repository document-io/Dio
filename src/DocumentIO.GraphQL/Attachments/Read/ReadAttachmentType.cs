namespace DocumentIO
{
	public class ReadAttachmentType : DocumentIOGraphType<CardAttachment>
	{
		public ReadAttachmentType()
		{
			Field(x => x.Id);
			Field(x => x.MimeType);
			Field(x => x.Content);

			DocumentIOField<ReadCardType, Card>("card")
				.Authorize(Roles.User)
				.ResolveAsync<AttachmentCardResolver>();

			DocumentIOField<ReadAccountType, Account>("account")
				.Authorize(Roles.User)
				.ResolveAsync<AttachmentAccountResolver>();
		}
	}
}