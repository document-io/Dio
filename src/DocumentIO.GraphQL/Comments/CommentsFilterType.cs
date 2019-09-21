namespace DocumentIO
{
	public class CommentsFilterType : DocumentIOFilterType<CardComment, CommentsFilter>
	{
		public CommentsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Content, nullable: true);
		}
	}
}