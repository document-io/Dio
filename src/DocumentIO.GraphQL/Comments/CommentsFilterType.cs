namespace DocumentIO
{
	public class CommentsFilterType : DocumentIOFilterType<CardComment, CommentsFilter>
	{
		public CommentsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Content);
			NullField(x => x.CreatedAt);
			NullField(x => x.UpdatedAt);
		}
	}
}