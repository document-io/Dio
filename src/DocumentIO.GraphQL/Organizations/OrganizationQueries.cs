using System.Linq;
using GraphQL.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class OrganizationQueries
	{
		public static void AddOrganizationQueries(this DocumentIOQueries queries)
		{
			queries.Field<ReadOrganizationGraphType, ReadOrganizationModel>()
				.Name("getOrganization")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					var organization = await databaseContext.Organizations
						.SingleAsync(x => x.Accounts.Any(a => a.Id == accountId));

					return new ReadOrganizationModel
					{
						Id = organization.Id,
						Name = organization.Name
					};
				});
		}
	}
}