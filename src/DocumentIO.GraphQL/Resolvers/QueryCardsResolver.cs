using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryCardsResolver : IDocumentIOResolver<object, IEnumerable<Card>>
	{		
		private readonly DatabaseContext databaseContext;

		public QueryCardsResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Card>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<CardsFilter>();

			var organization = await databaseContext.Organizations
				.AsNoTracking()
				.GetByAccountId(accountId);

			return await filter.Filtered(
					databaseContext.Cards.AsNoTracking(),
					cards => cards.Where(card => card.Column.Board.Organization == organization))
				.ToListAsync();
		}
	}
}