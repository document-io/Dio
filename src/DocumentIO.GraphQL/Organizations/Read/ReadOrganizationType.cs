using System.Collections.Generic;
using GraphQL.Types;

namespace DocumentIO
{
	public class ReadOrganizationType : DocumentIOGraphType<Organization>
	{
		public ReadOrganizationType()
		{
			Field(x => x.Id);
			Field(x => x.Name);

			DocumentIOField<ListGraphType<ReadAccountType>, IEnumerable<Account>>("accounts")
				.Filtered<AccountFilterType>()
				.ResolveAsync<OrganizationAccountsResolver>();

			DocumentIOField<ListGraphType<ReadInviteType>, IEnumerable<Invite>>("invites")
				.Filtered<InviteFilterType>()
				.ResolveAsync<OrganizationInvitesResolver>();

			DocumentIOField<ListGraphType<ReadBoardType>, IEnumerable<Board>>("boards")
				.Filtered<BoardsFilterType>()
				.ResolveAsync<OrganizationBoardsResolver>();
		}
	}
}