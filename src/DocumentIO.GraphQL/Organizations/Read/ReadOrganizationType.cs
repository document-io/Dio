using System;
using System.Collections.Generic;
using System.Linq;
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
				.Argument<AccountFilterType>("filter", q => q.DefaultValue = new AccountFilter())
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetArgument<AccountFilter>("filter");

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Account>(
						"OrganizationAccounts",
						async ids =>
							await filter.Filter(databaseContext.Accounts)
								.Where(account => ids.Contains(account.OrganizationId))
								.ToListAsync(),
						account => account.OrganizationId);

					return await loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadInviteType>, IEnumerable<Invite>>("invites")
				.Argument<InviteFilterType>("filter", q => q.DefaultValue = new InviteFilter())
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetArgument<InviteFilter>("filter");

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Invite>(
						"OrganizationInvites",
						async ids =>
							await filter.Filter(databaseContext.Invites)
								.Where(invite => ids.Contains(invite.OrganizationId))
								.ToListAsync(),
						invite => invite.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadBoardType>, IEnumerable<Board>>("boards")
				.Argument<BoardsFilterType>("filter", q => q.DefaultValue = new BoardsFilter())
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetArgument<BoardsFilter>("filter");

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Board>(
						"OrganizationBoards",
						async ids => 
							await filter.Filter(databaseContext.Boards)
								.Where(board => ids.Contains(board.OrganizationId))
								.ToListAsync(),
						board => board.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}