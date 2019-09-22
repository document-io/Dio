namespace DocumentIO
{
	public class CreateCommentType : DocumentIOInputGraphType<CardComment>
	{
		public CreateCommentType()
		{
			Field(x => x.Text);
			Field(x => x.CardId);
		}
	}
}