namespace DocumentIO
{
	public class ReadCommentType : DocumentIOGraphType<CardComment>
	{
		public ReadCommentType()
		{
			Field(x => x.Id);
			Field(x => x.Content);
			Field(x => x.CreatedAt);

			DocumentIOField<ReadCardType, Card>("card")
				.ResolveAsync<CommentCardResolver>();

			DocumentIOField<ReadAccountType, Account>("account")
				.ResolveAsync<CommentAccountResolver>();
		}
	}
}