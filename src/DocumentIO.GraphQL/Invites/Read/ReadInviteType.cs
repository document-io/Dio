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
			Field(x => x.DueDate, nullable: true);

			DocumentIOField<ReadAccountType, Account>("account")
				.Authorize(Roles.User)
				.ResolveAsync<InviteAccountResolver>();

			DocumentIOField<ReadOrganizationType, Organization>("organization")
				.Authorize(Roles.User)
				.ResolveAsync<InviteOrganizationResolver>();
		}
	}
}