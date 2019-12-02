using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AttachmentFilesResolver : IDocumentIOResolver<CardAttachment, IEnumerable<File>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public AttachmentFilesResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<IEnumerable<File>> Resolve(DocumentIOResolveFieldContext<CardAttachment> context)
		{
			var filter = context.GetFilter<FilesFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, File>(
				"AttachmentFiles",
				async ids =>
					await filter.Filtered(
							databaseContext.Files.AsNoTracking(),
							query: files => files.Where(label => ids.Contains(label.AttachmentId.Value)),
							orderBy: label => label.Id)
						.ToListAsync(),
				label => label.AttachmentId.Value);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}