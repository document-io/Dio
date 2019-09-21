using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ColumnBoardResolver : IDocumentIOResolver<Column, Board>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public ColumnBoardResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}
		
		public Task<Board> Resolve(DocumentIOResolveFieldContext<Column> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Board>(
				"ColumnBoard",
				async ids => await databaseContext.Columns
					.AsNoTracking()
					.Include(column => column.Board)
					.Where(column => ids.Contains(column.Id))
					.ToDictionaryAsync(column => column.Id, column => column.Board));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}