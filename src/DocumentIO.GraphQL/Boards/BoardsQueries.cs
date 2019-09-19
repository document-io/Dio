using System.Collections.Generic;
using System.Linq;
using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class BoardsQueries
	{
		public static void AddBoardsQueries(this DocumentIOQueries queries)
		{
			queries.Field<ListGraphType<ReadBoardGraphType>, List<ReadBoardModel>>("getBoards")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					return await databaseContext.Boards
						.Where(x => x.Organization.Accounts.Any(u => u.Id == accountId))
						.Select(x => new ReadBoardModel
						{
							Id = x.Id,
							OrganizationId = x.OrganizationId,
							Name = x.Name
						})
						.ToListAsync();
				});
		}
	}
}