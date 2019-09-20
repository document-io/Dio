using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AccountInviteResolver : IGraphQLResolver<Account, Invite>
	{
		private readonly IDataLoaderContextAccessor accessor;
		private readonly DatabaseContext databaseContext;

		public AccountInviteResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<Invite> Resolve(DocumentIOResolveFieldContext<Account> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Invite>(
				"AccountInvite",
				async ids => await databaseContext.Accounts
					.AsNoTracking()
					.Include(account => account.Invite)
					.Where(account => ids.Contains(account.Id))
					.ToDictionaryAsync(account => account.Id, account => account.Invite));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}