using System.Collections.Generic;
using System.Linq;
using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class AccountQueries
	{
		public static void AddAccountQueries(this DocumentIOQueries queries)
		{
			queries.Field<ReadAccountGraphType, ReadAccountModel>()
				.Name("getAccount")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					var account =  await databaseContext.Accounts.SingleAsync(x => x.Id == accountId);

					return new ReadAccountModel
					{
						Email = account.Email,
						Id = account.Id,
						CreatedAt = account.CreatedAt,
						FirstName = account.FirstName,
						LastName = account.LastName,
						MiddleName = account.MiddleName
					};
				});

			queries.Field<ListGraphType<ReadAccountGraphType>, List<ReadAccountModel>>()
				.Name("getAccounts")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					var organization = await databaseContext.Organizations
						.Include(x => x.Accounts)
						.SingleAsync(x => x.Accounts.Any(a => a.Id == accountId));

					return organization.Accounts
						.Select(x => new ReadAccountModel
						{
							Id = x.Id,
							Email = x.Email,
							CreatedAt = x.CreatedAt,
							FirstName = x.FirstName,
							LastName = x.LastName,
							MiddleName = x.MiddleName
						})
						.ToList();
				});
		}
	}
}