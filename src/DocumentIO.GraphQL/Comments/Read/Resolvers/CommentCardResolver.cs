using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CommentCardResolver : IDocumentIOResolver<CardComment, Card>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public CommentCardResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}

		public Task<Card> Resolve(DocumentIOResolveFieldContext<CardComment> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Card>(
				"CommentCard",
				async ids => await databaseContext.Cards.AsNoTracking()
					.Where(x => ids.Contains(x.Id))
					.ToDictionaryAsync(x => x.Id));

			return loader.LoadAsync(context.Source.CardId);
		}
	}
}