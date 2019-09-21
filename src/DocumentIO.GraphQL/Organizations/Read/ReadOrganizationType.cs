namespace DocumentIO
{
	public class ReadOrganizationType : DocumentIOGraphType<Organization>
	{
		public ReadOrganizationType()
		{
			Field(x => x.Id);
			Field(x => x.Name);

			DocumentIOListField<ReadAccountType, Account>("accounts")
				.Authorize(Roles.User)
				.Filtered<AccountFilterType>()
				.ResolveAsync<OrganizationAccountsResolver>();

			DocumentIOListField<ReadInviteType, Invite>("invites")
				.Authorize(Roles.Admin)
				.Filtered<InviteFilterType>()
				.ResolveAsync<OrganizationInvitesResolver>();

			DocumentIOListField<ReadBoardType, Board>("boards")
				.Authorize(Roles.User)
				.Filtered<BoardsFilterType>()
				.ResolveAsync<OrganizationBoardsResolver>();
		}
	}
}