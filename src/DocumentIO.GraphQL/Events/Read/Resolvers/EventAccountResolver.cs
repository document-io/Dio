using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class EventAccountResolver : IDocumentIOResolver<CardEvent, Account>
	{
		private readonly IDataLoaderContextAccessor accessor;
		private readonly DatabaseContext databaseContext;

		public EventAccountResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<Account> Resolve(DocumentIOResolveFieldContext<CardEvent> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Account>(
				"EventAccount",
				async ids => await databaseContext.CardEvents
					.AsNoTracking()
					.Include(assignment => assignment.Account)
					.Where(assignment => ids.Contains(assignment.AccountId))
					.ToDictionaryAsync(x => x.AccountId, x => x.Account));

			return loader.LoadAsync(context.Source.AccountId);
		}
	}
}