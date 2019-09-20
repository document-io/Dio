using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadLabelType : DocumentIOGraphType<Label>
	{
		public ReadLabelType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Description);
			Field(x => x.Color);

			Field<ReadBoardType, Board>("board")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Board>(
						"LabelBoard",
						async ids => await databaseContext.Labels
							.AsNoTracking()
							.Include(label => label.Board)
							.Where(label => ids.Contains(label.Id))
							.ToDictionaryAsync(label => label.Id, label => label.Board));

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadCardType>, IEnumerable<Card>, CardsFilterType>("cards")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Label, CardsFilter>();

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
				});
		}
	}
}