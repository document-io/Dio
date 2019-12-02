namespace DocumentIO
{
	public class ReadAttachmentType : DocumentIOGraphType<CardAttachment>
	{
		public ReadAttachmentType()
		{
			Field(x => x.Id);
			Field(x => x.CreatedAt);

			NonNullDocumentIOField<ReadCardType, Card>("card")
				.AllowUser()
				.ResolveAsync<AttachmentCardResolver>();

			NonNullDocumentIOField<ReadAccountType, Account>("account")
				.AllowUser()
				.ResolveAsync<AttachmentAccountResolver>();

			DocumentIOListField<ReadFileType, File>("files")
				.AllowUser()
				.ResolveAsync<AttachmentFilesResolver>();
		}
	}
}