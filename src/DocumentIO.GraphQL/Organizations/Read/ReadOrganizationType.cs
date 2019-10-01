namespace DocumentIO
{
	public class ReadOrganizationType : DocumentIOGraphType<Organization>
	{
		public ReadOrganizationType()
		{
			Field(x => x.Id);
			Field(x => x.Name);

			DocumentIOListField<ReadAccountType, Account>("accounts")
				.AllowUser()
				.Filtered<AccountsFilterType>()
				.ResolveAsync<OrganizationAccountsResolver>();

			DocumentIOListField<ReadInviteType, Invite>("invites")
				.AllowAdmin()
				.Filtered<InvitesFilterType>()
				.ResolveAsync<OrganizationInvitesResolver>();

			DocumentIOListField<ReadBoardType, Board>("boards")
				.AllowUser()
				.Filtered<BoardsFilterType>()
				.ResolveAsync<OrganizationBoardsResolver>();
		}
	}
}