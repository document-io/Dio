using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteCardLabelResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCardLabelResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var input = context.GetArgument<CardLabel>();

			var cardLabel = await databaseContext
				.CardLabels
				.Include(x => x.Label)
				.SingleAsync(x => x.CardId == input.CardId && x.LabelId == input.LabelId);

			databaseContext.CardLabels.Remove(cardLabel);

			var card = await databaseContext.Cards
				.Include(x => x.Assignments)
				.FirstOrDefaultAsync(x => x.Id == cardLabel.CardId);

			await databaseContext.CardEvents.AddRangeAsync(card.Assignments
				.Select(x => new CardEvent
				{
					Card = card,
					AccountId = x.AccountId,
					CreatedAt = DateTime.UtcNow,
					Content = $"У карточки ''{card.Name}' удалена метка '{cardLabel.Label.Name}'"
				}));

			await databaseContext.SaveChangesAsync();

			return await databaseContext.Cards.SingleAsync(x => x.Id == input.CardId);
		}
	}
}