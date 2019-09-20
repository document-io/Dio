using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CardLabelsResolver : IGraphQLResolver<Card, IEnumerable<Label>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public CardLabelsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public async Task<IEnumerable<Label>> Resolve(DocumentIOResolveFieldContext<Card> context)
		{
			var filter = context.GetFilter<LabelsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardLabel>(
				"CardLabels",
				async ids =>
					await filter.Filtered(
							databaseContext.Labels.AsNoTracking(),
							labels => labels.SelectMany(label => label.Cards)
								.Include(cardLabel => cardLabel.Label)
								.Where(cardLabel => ids.Contains(cardLabel.CardId)))
						.ToListAsync(),
				cardLabel => cardLabel.CardId);

			var cardLabels = await loader.LoadAsync(context.Source.Id);

			return cardLabels.Select(cardLabel => cardLabel.Label).ToList();
		}
	}
}