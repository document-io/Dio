using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryEventsResovler : IGraphQLResolver<object, IEnumerable<CardEvent>>
	{		
		private readonly DatabaseContext databaseContext;

		public QueryEventsResovler(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<CardEvent>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<EventsFilter>();

			var organization = await databaseContext.Organizations
				.AsNoTracking()
				.GetByAccountId(accountId);

			return await filter.Filtered(
					databaseContext.CardEvents.AsNoTracking(),
					events => events.Where(@event => @event.Account.Organization == organization))
				.ToListAsync();
		}
	}
}