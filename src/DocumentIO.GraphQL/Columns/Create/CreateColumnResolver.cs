using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateColumnResolver : IDocumentIOResolver<object, Column>
	{
		private readonly DatabaseContext databaseContext;

		public CreateColumnResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Column> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var column = context.GetArgument<Column>();

			var board = await databaseContext.Boards
				.Include(x => x.Columns)
				.SingleAsync(x => x.Id == column.BoardId);

			column.Board = board;
			column.Order = board.Columns.Count + 1;

			await databaseContext.Columns.AddAsync(column);
			await databaseContext.SaveChangesAsync();

			return column;
		}
	}
}