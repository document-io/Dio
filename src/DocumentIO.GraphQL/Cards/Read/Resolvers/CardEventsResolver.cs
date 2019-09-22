using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CardEventsResolver : IDocumentIOResolver<Card, IEnumerable<CardEvent>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public CardEventsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
	
		public Task<IEnumerable<CardEvent>> Resolve(DocumentIOResolveFieldContext<Card> context)
		{
			var filter = context.GetFilter<EventsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardEvent>(
				"CardEvents",
				async ids =>
					await filter.Filtered(
							databaseContext.CardEvents.AsNoTracking(),
							query: events => events.Where(@event => ids.Contains(@event.CardId)),
							orderBy: @event => @event.CreatedAt)
						.ToListAsync(),
				cardLabel => cardLabel.CardId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}