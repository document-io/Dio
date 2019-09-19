using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadBoardGraphType : ObjectGraphType<ReadBoardModel>
	{
		public ReadBoardGraphType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);

			Field<ListGraphType<ReadColumnGraphType>, IEnumerable<ReadColumnModel>>("columns")
				.ResolveAsync(context =>
				{
					var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, ReadColumnModel>(
						"BoardColumns",
						async ids =>
						{
							return await context.GetDatabaseContext()
								.Columns
								.AsNoTracking()
								.Where(x => ids.Contains(x.BoardId))
								.Select(x => new ReadColumnModel
								{
									Id = x.Id,
									BoardId = x.BoardId,
									Name = x.Name,
									Order = x.Order
								})
								.ToListAsync();
						},
						x => x.BoardId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}