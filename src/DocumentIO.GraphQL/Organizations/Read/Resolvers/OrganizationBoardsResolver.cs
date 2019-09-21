using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class OrganizationBoardsResolver : IDocumentIOResolver<Organization, IEnumerable<Board>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public OrganizationBoardsResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}

		public Task<IEnumerable<Board>> Resolve(DocumentIOResolveFieldContext<Organization> context)
		{
			var filter = context.GetFilter<BoardsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Board>(
				"OrganizationBoards",
				async ids =>
					await filter.Filtered(
							databaseContext.Boards.AsNoTracking(),
							boards => boards.Where(board => ids.Contains(board.OrganizationId)))
						.ToListAsync(),
				board => board.OrganizationId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}