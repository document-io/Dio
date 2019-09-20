using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class BoardColumnsResolver : IGraphQLResolver<Board, IEnumerable<Column>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public BoardColumnsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<IEnumerable<Column>> Resolve(DocumentIOResolveFieldContext<Board> context)
		{
			var filter = context.GetFilter<ColumnsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Column>(
				"BoardColumns",
				async ids =>
					await filter.Filtered(
							databaseContext.Columns.AsNoTracking(),
							columns => columns.Where(column => ids.Contains(column.BoardId)))
						.ToListAsync(),
				column => column.BoardId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}