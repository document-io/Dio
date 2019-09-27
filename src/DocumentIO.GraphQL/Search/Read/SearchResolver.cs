using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class SearchResolver : IDocumentIOResolver<IEnumerable<Search>>
	{
		private readonly DatabaseContext databaseContext;

		public SearchResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Search>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<SearchFilter>();

			var boards = await filter.Filtered(
				databaseContext.Boards.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId)),
				x => x,
				search => search.CreatedAt)
				.ToListAsync();

			var columns = await filter.Filtered(
				databaseContext.Columns.Where(x => x.Board.Organization.Accounts.Any(account => account.Id == accountId)),
				x => x,
				search => search.CreatedAt)
				.ToListAsync();

			var cards = await filter.Filtered(
				databaseContext.Cards.Where(x => x.Column.Board.Organization.Accounts.Any(account => account.Id == accountId)),
				x => x,
				search => search.CreatedAt)
				.ToListAsync();

			return boards.Concat(columns).Concat(cards);
		}
	}
}