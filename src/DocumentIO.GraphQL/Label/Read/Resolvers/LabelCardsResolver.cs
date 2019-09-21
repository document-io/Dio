using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class LabelCardsResolver : IDocumentIOResolver<Label, IEnumerable<Card>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public LabelCardsResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}

		public async Task<IEnumerable<Card>> Resolve(DocumentIOResolveFieldContext<Label> context)
		{
			var filter = context.GetFilter<CardsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardLabel>(
				"LabelCards",
				async ids => 
					await filter.Filtered(
							databaseContext.Cards.AsNoTracking(),
							cards => cards
								.SelectMany(card => card.Labels)
								.Include(cardLabel => cardLabel.Card)
								.Where(cardLabel => ids.Contains(cardLabel.LabelId)))
						.ToListAsync(),
				cardLabel => cardLabel.LabelId);

			var cardLabels = await loader.LoadAsync(context.Source.Id);

			return cardLabels.Select(cardLabel => cardLabel.Card).ToList();
		}
	}
}