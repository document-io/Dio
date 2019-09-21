using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class LabelBoardResolver : IDocumentIOResolver<Label, Board>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public LabelBoardResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<Board> Resolve(DocumentIOResolveFieldContext<Label> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Board>(
				"LabelBoard",
				async ids => await databaseContext.Labels
					.AsNoTracking()
					.Include(label => label.Board)
					.Where(label => ids.Contains(label.Id))
					.ToDictionaryAsync(label => label.Id, label => label.Board));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}