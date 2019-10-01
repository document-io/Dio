using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class EventsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public EventsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<EventsFilter>();

			return filter.Filtered(
					databaseContext.CardEvents.AsNoTracking(),
					events => events.Where(@event => @event
						.Account
						.Organization
						.Accounts
						.Any(account => account.Id == accountId)),
					@event => @event.CreatedAt)
				.CountAsync();
		}
	}
}