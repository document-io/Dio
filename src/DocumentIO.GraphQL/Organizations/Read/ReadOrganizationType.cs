namespace DocumentIO
{
	public class ReadOrganizationType : DocumentIOGraphType<Organization>
	{
		public ReadOrganizationType()
		{
			Field(x => x.Id);
			Field(x => x.Name);

			DocumentIOListField<ReadAccountType, Account>("accounts")
				.Filtered<AccountFilterType>()
				.ResolveAsync<OrganizationAccountsResolver>();

			DocumentIOListField<ReadInviteType, Invite>("invites")
				.Filtered<InviteFilterType>()
				.ResolveAsync<OrganizationInvitesResolver>();

			DocumentIOListField<ReadBoardType, Board>("boards")
				.Filtered<BoardsFilterType>()
				.ResolveAsync<OrganizationBoardsResolver>();
		}
	}
}