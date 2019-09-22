namespace DocumentIO
{
	public class ReadCommentType : DocumentIOGraphType<CardComment>
	{
		public ReadCommentType()
		{
			Field(x => x.Id);
			Field(x => x.Text);
			Field(x => x.CreatedAt);
			NullField(x => x.UpdatedAt);

			NonNullDocumentIOField<ReadCardType, Card>("card")
				.Authorize(Roles.User)
				.ResolveAsync<CommentCardResolver>();

			NonNullDocumentIOField<ReadAccountType, Account>("account")
				.Authorize(Roles.User)
				.ResolveAsync<CommentAccountResolver>();
		}
	}
}