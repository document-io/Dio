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
				.ResolveAsync<AttachmentCardResolver>();

			DocumentIOField<ReadAccountType, Account>("account")
				.ResolveAsync<AttachmentAccountResolver>();
		}
	}
}