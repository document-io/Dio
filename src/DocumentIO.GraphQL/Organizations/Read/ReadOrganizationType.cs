using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadOrganizationType : ObjectGraphType<Organization>
	{
		public ReadOrganizationType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);

			Field<ListGraphType<ReadAccountType>, IEnumerable<Account>>("accounts")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Account>(
						"OrganizationAccounts",
						async ids => await databaseContext.Accounts
							.Where(account => ids.Contains(account.OrganizationId))
							.ToListAsync(),
						account => account.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadInviteType>, IEnumerable<Invite>>("invites")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Invite>(
						"OrganizationInvites",
						async ids => await databaseContext.Invites
							.Where(invite => ids.Contains(invite.OrganizationId))
							.ToListAsync(),
						invite => invite.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadBoardType>, IEnumerable<Board>>("boards")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Board>(
						"OrganizationBoards",
						async ids => await databaseContext.Boards
							.Where(board => ids.Contains(board.OrganizationId))
							.ToListAsync(),
						board => board.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}