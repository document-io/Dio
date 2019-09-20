using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AccountOrganizationResolver : IGraphQLResolver<Account, Organization>
	{
		private readonly IDataLoaderContextAccessor accessor;
		private readonly DatabaseContext databaseContext;

		public AccountOrganizationResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<Organization> Resolve(DocumentIOResolveFieldContext<Account> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Organization>(
				"AccountOrganization",
				async ids => await databaseContext.Accounts
					.AsNoTracking()
					.Include(account => account.Organization)
					.Where(account => ids.Contains(account.Id))
					.ToDictionaryAsync(account => account.Id, account => account.Organization));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}