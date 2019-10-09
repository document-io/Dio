using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateCardResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public UpdateCardResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<Card>();

			var card = await databaseContext.Cards
				.Include(x => x.Assignments)
				.SingleAsync(x => x.Id == model.Id);

			if (model.Name != null)
			{
				card.Name = model.Name;
			}

			if (model.Order != 0)
			{
				var cards = await databaseContext
					.Cards
					.Where(x => x.ColumnId == card.ColumnId)
					.ToListAsync();

				UpdateCardsOrder(cards, model);
			}

			if (model.DueDate != null)
			{
				card.DueDate = model.DueDate;
			}

			if (model.Content != null)
			{
				card.Content = model.Content;
			}

			await databaseContext.CardEvents.AddRangeAsync(card.Assignments
				.Select(x => new CardEvent
				{
					Card = card,
					AccountId = x.AccountId,
					CreatedAt = DateTime.UtcNow,
					Content = $"Карточка '{card.Name}' была отредактирована"
				}));

			await databaseContext.SaveChangesAsync();

			return card;
		}
		
		public void UpdateCardsOrder(ICollection<Card> cards, Card model)
		{
			cards = cards.OrderBy(x => x.Order).ToList();

			var cardToUpdate = cards.Single(x => x.Id == model.Id);

			var previousOrder = cardToUpdate.Order;
			var nextOrder = model.Order;

			if (previousOrder == nextOrder)
				return;

			// если был 0, а стал 1
			if (previousOrder < nextOrder)
			{
				var cardsToDecrement = cards
					.Skip(previousOrder)
					.Take(nextOrder - previousOrder)
					.ToList();

				foreach (var column in cardsToDecrement)
				{
					column.Order--;
				}
			}
			// если был 2, а стал 1
			else
			{
				var cardsToIncrement = cards
					.Skip(nextOrder - 1)
					.Take(previousOrder - nextOrder)
					.ToList();

				foreach (var column in cardsToIncrement)
				{
					column.Order++;
				}
			}

			cardToUpdate.Order = nextOrder;
		}
	}
}