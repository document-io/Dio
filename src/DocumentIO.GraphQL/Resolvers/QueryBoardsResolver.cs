using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryBoardsResolver : IDocumentIOResolver<object, IEnumerable<Board>>
	{
		private readonly DatabaseContext databaseContext;

		public QueryBoardsResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Board>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<BoardsFilter>();

			return await filter.Filtered(
					databaseContext.Boards.AsNoTracking(),
					boards => boards.Where(board =>
						board.Organization.Accounts.Any(account => account.Id == accountId)))
				.ToListAsync();
		}
	}
}