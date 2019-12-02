using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryFilesResolver : IDocumentIOResolver<IEnumerable<File>>
	{
		private readonly DatabaseContext databaseContext;

		public QueryFilesResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<File>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<FilesFilter>();

			return await filter.Filtered(
					databaseContext.Files.AsNoTracking(),
					query: events => events.Where(@event =>
						@event.Attachment.Card.Column.Board.Organization.Accounts.Any(account => account.Id == accountId)),
					orderBy: @event => @event.Id)
				.ToListAsync();
		}
	}
}