using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateCardLabelResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public CreateCardLabelResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var cardLabel = context.GetArgument<CardLabel>();

			var card = await databaseContext.Cards
				.Include(x => x.Assignments)
				.FirstOrDefaultAsync(x => x.Id == cardLabel.CardId);

			var label = await databaseContext.Labels
				.FirstAsync(x => x.Id == cardLabel.LabelId);

			await databaseContext.CardEvents.AddRangeAsync(card.Assignments
				.Select(x => new CardEvent
				{
					Card = card,
					AccountId = x.AccountId,
					CreatedAt = DateTime.UtcNow,
					Content = $"К карточке '{card.Name}'' добавлена метка '{label.Name}'"
				}));

			await databaseContext.CardLabels.AddAsync(cardLabel);

			await databaseContext.SaveChangesAsync();

			return await databaseContext.Cards.SingleAsync(x => x.Id == cardLabel.CardId);
		}
	}
}