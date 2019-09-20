using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryAccountsResolver : IGraphQLResolver<object, IEnumerable<Account>>
	{		
		private readonly DatabaseContext databaseContext;

		public QueryAccountsResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Account>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<AccountFilter>();

			var organization = await databaseContext.Organizations
				.AsNoTracking()
				.GetByAccountId(accountId);

			return await filter.Filtered(
					databaseContext.Accounts.AsNoTracking(),
					accounts => accounts.Where(account => account.Organization == organization))
				.ToListAsync();
		}
	}
}