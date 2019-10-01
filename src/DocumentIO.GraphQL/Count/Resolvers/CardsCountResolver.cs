using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CardsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public CardsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<CardsFilter>();

			return filter.Filtered(
					databaseContext.Cards.AsNoTracking(),
					cards => cards.Where(card => card
						.Column
						.Board
						.Organization
						.Accounts
						.Any(account => account.Id == accountId)),
					card => card.CreatedAt)
				.CountAsync();
		}
	}
}