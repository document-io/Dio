using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateCommentResolver : IDocumentIOResolver<CardComment>
	{
		private readonly DatabaseContext databaseContext;

		public CreateCommentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<CardComment> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var comment = context.GetArgument<CardComment>();

			comment.AccountId = accountId;
			comment.CreatedAt = DateTime.UtcNow;

			var card = await databaseContext.Cards
				.Include(x => x.Assignments)
				.FirstOrDefaultAsync(x => x.Id == comment.CardId);

			await databaseContext.CardEvents.AddRangeAsync(card.Assignments
				.Select(x => new CardEvent
				{
					Card = card,
					AccountId = x.AccountId,
					CreatedAt = DateTime.UtcNow,
					Content = $"К карточке '{card.Name}' добавлен комментарий"
				}));

			await databaseContext.CardComments.AddAsync(comment);
			await databaseContext.SaveChangesAsync();

			return comment;
		}
	}
}