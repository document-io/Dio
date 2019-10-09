using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateCardResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public CreateCardResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var card = context.GetArgument<Card>();

			var column = await databaseContext.Columns
				.Include(x => x.Cards)
				.SingleAsync(x => x.Id == card.ColumnId);

			card.Column = column;
			card.Order = column.Cards.Count + 1;
			card.CreatedAt = DateTime.UtcNow;

			await databaseContext.Cards.AddAsync(card);

			await databaseContext.CardAssignments
				.AddAsync(new CardAssignment
				{
					Card = card,
					AccountId = context.GetAccountId()
				});
			
			await databaseContext.SaveChangesAsync();

			return card;
		}
	}
}