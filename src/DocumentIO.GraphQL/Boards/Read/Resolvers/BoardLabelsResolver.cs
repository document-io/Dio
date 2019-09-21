using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class BoardLabelsResolver : IDocumentIOResolver<Board, IEnumerable<Label>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public BoardLabelsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<IEnumerable<Label>> Resolve(DocumentIOResolveFieldContext<Board> context)
		{
			var filter = context.GetFilter<LabelsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Label>(
				"BoardLabels",
				async ids =>
					await filter.Filtered(
							databaseContext.Labels.AsNoTracking(),
							labels => labels.Where(label => ids.Contains(label.BoardId)))
						.ToListAsync(),
				label => label.BoardId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}