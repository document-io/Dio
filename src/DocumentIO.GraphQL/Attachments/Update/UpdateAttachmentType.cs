namespace DocumentIO
{
	public class UpdateAttachmentType : DocumentIOInputGraphType<CardAttachment>
	{
		public UpdateAttachmentType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
		}
	}
}