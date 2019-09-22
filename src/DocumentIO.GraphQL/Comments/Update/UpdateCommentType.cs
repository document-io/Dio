namespace DocumentIO
{
	public class UpdateCommentType : DocumentIOInputGraphType<CardComment>
	{
		public UpdateCommentType()
		{
			Field(x => x.Id);
			Field(x => x.Text);
		}
	}
}