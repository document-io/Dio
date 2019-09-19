using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DocumentIOQueries : ObjectGraphType
	{
		public DocumentIOQueries()
		{
			Name = "Queries";

			Field<ReadOrganizationType, Organization>("organization")
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					return await databaseContext.Organizations
						.SingleAsync(organization =>
							organization.Accounts.Any(account => account.Id == accountId));
				});
		}
	}
}