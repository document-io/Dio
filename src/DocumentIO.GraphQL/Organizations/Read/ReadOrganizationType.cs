using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadOrganizationType : DocumentIOGraphType<Organization>
	{
		public ReadOrganizationType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);

			FilteredField<ListGraphType<ReadAccountType>, IEnumerable<Account>, AccountFilterType>("accounts")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Organization, AccountFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Account>(
						"OrganizationAccounts",
						async ids =>
							await filter.Filtered(
									databaseContext.Accounts,
									accounts => accounts.Where(account => ids.Contains(account.OrganizationId)))
								.ToListAsync(),
						account => account.OrganizationId);

					return await loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadInviteType>, IEnumerable<Invite>, InviteFilterType>("invites")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Organization, InviteFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Invite>(
						"OrganizationInvites",
						async ids =>
							await filter.Filtered(
									databaseContext.Invites,
									invites => invites.Where(invite => ids.Contains(invite.OrganizationId)))
								.ToListAsync(),
						invite => invite.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadBoardType>, IEnumerable<Board>, BoardsFilterType>("boards")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Organization, BoardsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Board>(
						"OrganizationBoards",
						async ids =>
							await filter.Filtered(
									databaseContext.Boards,
									boards => boards.Where(board => ids.Contains(board.OrganizationId)))
								.ToListAsync(),
						board => board.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}