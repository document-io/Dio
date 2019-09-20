using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class InviteAccountResolver : IGraphQLResolver<Invite, Account>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public InviteAccountResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}

		public Task<Account> Resolve(DocumentIOResolveFieldContext<Invite> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Account>(
				"InviteAccount",
				async ids => await databaseContext.Invites
					.AsNoTracking()
					.Include(invite => invite.Account)
					.Where(invite => ids.Contains(invite.Id))
					.ToDictionaryAsync(invite => invite.Id, invite => invite.Account));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}