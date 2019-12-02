namespace DocumentIO
{
	public class DeleteCardAttachmentType : DocumentIOInputGraphType<CardAttachment>
	{
		public DeleteCardAttachmentType()
		{
			Field(x => x.Id);
		}
	}
}