namespace DocumentIO
{
	public class CreateCardAttachmentType : DocumentIOInputGraphType<CardAttachment>
	{
		public CreateCardAttachmentType()
		{
			Field(x => x.Name);
			Field(x => x.CardId);
		}
	}
}