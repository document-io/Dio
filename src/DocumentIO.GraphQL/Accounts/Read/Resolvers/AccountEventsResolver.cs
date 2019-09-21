using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AccountEventsResolver : IDocumentIOResolver<Account, IEnumerable<CardEvent>>
	{
		private readonly IDataLoaderContextAccessor accessor;
		private readonly DatabaseContext databaseContext;

		public AccountEventsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<IEnumerable<CardEvent>> Resolve(DocumentIOResolveFieldContext<Account> context)
		{
			var filter = context.GetFilter<EventsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardEvent>(
				"AccountEvents",
				async ids =>
					await filter.Filtered(
							databaseContext.CardEvents.AsNoTracking(),
							events => events.Where(cardLabel => ids.Contains(cardLabel.AccountId)))
						.ToListAsync(),
				cardLabel => cardLabel.AccountId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}