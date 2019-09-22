using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateColumnResolver : IDocumentIOResolver<Column>
	{
		private readonly DatabaseContext databaseContext;

		public UpdateColumnResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Column> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<Column>();

			var column = await databaseContext.Columns.SingleAsync(x => x.Id == model.Id);

			if (model.Name != null)
				column.Name = model.Name;

			if (model.Order != 0)
			{
				var board = await databaseContext.Boards
					.Include(x => x.Columns)
					.SingleAsync(x => x.Id == column.BoardId);

				UpdateColumnsOrder(board.Columns, model);
			}

			await databaseContext.SaveChangesAsync();

			return column;
		}

		public void UpdateColumnsOrder(ICollection<Column> columns, Column model)
		{
			columns = columns.OrderBy(x => x.Order).ToList();

			var columnToUpdate = columns.Single(x => x.Id == model.Id);

			var previousOrder = columnToUpdate.Order;
			var nextOrder = model.Order;

			if (previousOrder == nextOrder)
				return;

			// если был 0, а стал 1
			if (previousOrder < nextOrder)
			{
				var columnsToDecrement = columns
					.Skip(previousOrder)
					.Take(nextOrder - previousOrder)
					.ToList();

				foreach (var column in columnsToDecrement)
				{
					column.Order--;
				}
			}
			// если был 2, а стал 1
			else
			{
				var columnsToIncrement = columns
					.Skip(nextOrder - 1)
					.Take(previousOrder - nextOrder)
					.ToList();

				foreach (var column in columnsToIncrement)
				{
					column.Order++;
				}
			}

			columnToUpdate.Order = nextOrder;
		}
	}
}
