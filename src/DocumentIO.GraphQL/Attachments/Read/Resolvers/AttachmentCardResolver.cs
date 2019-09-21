using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AttachmentCardResolver : IDocumentIOResolver<CardAttachment, Card>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public AttachmentCardResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<Card> Resolve(DocumentIOResolveFieldContext<CardAttachment> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Card>(
				"AttachmentCard",
				async ids => await databaseContext.CardAttachments.AsNoTracking()
					.Include(assignment => assignment.Card)
					.Where(assignment => ids.Contains(assignment.CardId))
					.ToDictionaryAsync(x => x.CardId, x => x.Card));

			return loader.LoadAsync(context.Source.CardId);
		}
	}
}