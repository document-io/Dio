using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class BoardOrganizationResolver : IGraphQLResolver<Board, Organization>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public BoardOrganizationResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<Organization> Resolve(DocumentIOResolveFieldContext<Board> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Organization>(
				"BoardOrganization",
				async ids => await databaseContext.Boards
					.AsNoTracking()
					.Include(board => board.Organization)
					.Where(board => ids.Contains(board.Id))
					.ToDictionaryAsync(board => board.Id, board => board.Organization));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}