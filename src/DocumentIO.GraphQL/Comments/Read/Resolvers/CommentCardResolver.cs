using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CommentCardResolver : IGraphQLResolver<CardComment, Card>
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
				async ids => await databaseContext.CardComments
					.AsNoTracking()
					.Include(assignment => assignment.Card)
					.Where(assignment => ids.Contains(assignment.CardId))
					.ToDictionaryAsync(x => x.CardId, x => x.Card));

			return loader.LoadAsync(context.Source.CardId);
		}
	}
}