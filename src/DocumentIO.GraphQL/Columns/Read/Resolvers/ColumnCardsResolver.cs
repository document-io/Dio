using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ColumnCardsResolver : IDocumentIOResolver<Column, IEnumerable<Card>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public ColumnCardsResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}

		public Task<IEnumerable<Card>> Resolve(DocumentIOResolveFieldContext<Column> context)
		{
			var filter = context.GetFilter<CardsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Card>(
				"ColumnCards",
				async ids => 
					await filter.Filtered(
							databaseContext.Cards.AsNoTracking(),
							query: cards => cards.Where(card => ids.Contains(card.ColumnId)),
							orderBy: card => card.Order)
						.ToListAsync(),
				card => card.ColumnId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}