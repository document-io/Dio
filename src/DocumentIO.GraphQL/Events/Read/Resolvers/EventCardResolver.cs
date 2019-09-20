using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class EventCardResolver : IGraphQLResolver<CardEvent, Card>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public EventCardResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}
	
		public Task<Card> Resolve(DocumentIOResolveFieldContext<CardEvent> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Card>(
				"EventCard",
				async ids => await databaseContext.CardEvents
					.AsNoTracking()
					.Include(assignment => assignment.Card)
					.Where(assignment => ids.Contains(assignment.CardId))
					.ToDictionaryAsync(x => x.CardId, x => x.Card));

			return loader.LoadAsync(context.Source.CardId);
		}
	}
}