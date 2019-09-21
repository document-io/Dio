using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CardCommentsResolver : IDocumentIOResolver<Card, IEnumerable<CardComment>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public CardCommentsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
	
		public Task<IEnumerable<CardComment>> Resolve(DocumentIOResolveFieldContext<Card> context)
		{
			var filter = context.GetFilter<CommentsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardComment>(
				"CardComments",
				async ids =>
					await filter.Filtered(
							databaseContext.CardComments.AsNoTracking(),
							comments => comments.Where(comment => ids.Contains(comment.CardId)))
						.ToListAsync(),
				cardLabel => cardLabel.CardId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}