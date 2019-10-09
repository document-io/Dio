using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateAssignmentResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public CreateAssignmentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var assigmnemt = context.GetArgument<CardAssignment>();

			assigmnemt.CreatedAt = DateTime.UtcNow;

			var card = await databaseContext.Cards
				.Include(x => x.Assignments)
				.FirstOrDefaultAsync(x => x.Id == assigmnemt.CardId);

			await databaseContext.CardEvents.AddRangeAsync(card.Assignments
				.Select(x => new CardEvent
				{
					Card = card,
					AccountId = x.AccountId,
					CreatedAt = DateTime.UtcNow,
					Content = $"Вы присоединились к карточке ''{card.Name}'"
				}));

			await databaseContext.CardAssignments.AddAsync(assigmnemt);

			await databaseContext.SaveChangesAsync();

			return await databaseContext.Cards.SingleAsync(x => x.Id == assigmnemt.CardId);
		}
	}
}