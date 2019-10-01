using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class BoardsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public BoardsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<BoardsFilter>();

			return filter.Filtered(
					databaseContext.Boards.AsNoTracking(),
					boards => boards.Where(board => board.Organization.Accounts.Any(account => account.Id == accountId)),
					board => board.CreatedAt)
				.CountAsync();
		}
	}
}