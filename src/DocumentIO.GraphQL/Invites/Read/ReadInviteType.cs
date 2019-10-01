namespace DocumentIO
{
	public class ReadInviteType : DocumentIOGraphType<Invite>
	{
		public ReadInviteType()
		{
			Field(x => x.Id);
			Field(x => x.Secret);
			Field(x => x.Role);
			Field(x => x.Description);
			Field(x => x.CreatedAt);
			NullField(x => x.DueDate);

			NonNullDocumentIOField<ReadAccountType, Account>("account")
				.AllowUser()
				.ResolveAsync<InviteAccountResolver>();

			NonNullDocumentIOField<ReadOrganizationType, Organization>("organization")
				.AllowUser()
				.ResolveAsync<InviteOrganizationResolver>();
		}
	}
}