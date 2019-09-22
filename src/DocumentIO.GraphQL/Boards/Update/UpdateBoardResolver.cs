using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateBoardResolver : IDocumentIOResolver<Board>
	{
		private readonly DatabaseContext databaseContext;

		public UpdateBoardResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Board> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Board>();

			var board = await databaseContext
				.Boards
				.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId))
				.SingleAsync(x => x.Id == model.Id);

			if (model.Name != null)
				board.Name = model.Name;

			await databaseContext.SaveChangesAsync();

			return board;
		}
	}
}