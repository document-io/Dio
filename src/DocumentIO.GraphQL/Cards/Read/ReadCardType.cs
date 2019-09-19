using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadCardType : ObjectGraphType<Card>
	{
		public ReadCardType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Order);
			Field(x => x.DueDate, nullable: true);
			Field(x => x.Markdown);

			Field<ReadColumnType, Column>("column")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Column>(
						"CardColumn",
						async ids => await databaseContext.Cards
							.Include(card => card.Column)
							.Where(card => ids.Contains(card.Id))
							.ToDictionaryAsync(card => card.Id, card => card.Column));

					return loader.LoadAsync(context.Source.Id);
				});
			
			Field<ListGraphType<ReadLabelType>, IEnumerable<Label>>("labels")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardLabel>(
						"CardLabels",
						async ids => await databaseContext.CardLabels
							.Include(cardLabel => cardLabel.Label)
							.Where(cardLabel => ids.Contains(cardLabel.CardId))
							.ToListAsync(),
						cardLabel => cardLabel.CardId);

					var cardLabels = await loader.LoadAsync(context.Source.Id);

					return cardLabels.Select(cardLabel => cardLabel.Label).ToList();
				});
		}
	}
}