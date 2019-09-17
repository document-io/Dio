using System.Collections.Generic;
using System.Linq;
using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class InviteQueries
	{
		public static void AddInviteQueries(this DocumentIOQueries queries)
		{
			queries.Field<ListGraphType<ReadInviteGraphType>, List<ReadInviteModel>>()
				.Name("getInvites")
				.AuthorizeWith(Roles.Admin)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					return await databaseContext
						.Invites
						.Where(x => x.Organization.Accounts.Any(a => a.Id == accountId))
						.Select(x => new ReadInviteModel
						{
							Id = x.Id,
							Description = x.Description,
							Email = x.Email,
							Identifier = x.Identifier,
							Role = x.Role,
							CreatedAt = x.CreatedAt,
							DueDate = x.DueDate
						})
						.ToListAsync();
				});

		}
	}
}