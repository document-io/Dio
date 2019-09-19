using GraphQL.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class OrganizationQueries
	{
		public static void AddOrganizationQueries(this DocumentIOQueries queries)
		{
			queries.Field<ReadOrganizationGraphType, ReadOrganizationModel>("getOrganization")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					var account = await databaseContext.Accounts
						.Include(x => x.Organization)
						.SingleAsync(x => x.Id == accountId);

					var organization = account.Organization;

					return new ReadOrganizationModel
					{
						Id = organization.Id,
						Name = organization.Name
					};
				});
		}
	}
}