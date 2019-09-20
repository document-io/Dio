using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class OrganizationAccountsResolver : IGraphQLResolver<Organization, IEnumerable<Account>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public OrganizationAccountsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<IEnumerable<Account>> Resolve(DocumentIOResolveFieldContext<Organization> context)
		{
			var filter = context.GetFilter<AccountFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Account>(
				"OrganizationAccounts",
				async ids =>
					await filter.Filtered(
							databaseContext.Accounts.AsNoTracking(),
							accounts => accounts.Where(account => ids.Contains(account.OrganizationId)))
						.ToListAsync(),
				account => account.OrganizationId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}