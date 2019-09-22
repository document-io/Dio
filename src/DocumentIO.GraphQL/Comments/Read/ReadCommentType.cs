namespace DocumentIO
{
	public class ReadCommentType : DocumentIOGraphType<CardComment>
	{
		public ReadCommentType()
		{
			Field(x => x.Id);
			Field(x => x.Content);
			Field(x => x.CreatedAt);
			Field(x => x.UpdatedAt, nullable: true);

			DocumentIOField<ReadCardType, Card>("card")
				.Authorize(Roles.User)
				.ResolveAsync<CommentCardResolver>();

			DocumentIOField<ReadAccountType, Account>("account")
				.Authorize(Roles.User)
				.ResolveAsync<CommentAccountResolver>();
		}
	}
}