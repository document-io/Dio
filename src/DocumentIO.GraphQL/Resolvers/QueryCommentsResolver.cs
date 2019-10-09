using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryCommentsResolver : IDocumentIOResolver<IEnumerable<CardComment>>
	{
		private readonly DatabaseContext databaseContext;

		public QueryCommentsResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<CardComment>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<CommentsFilter>();

			return await filter.Filtered(
					databaseContext.CardComments.AsNoTracking(),
					comments => comments.Where(comment =>
						comment.Account.Organization.Accounts.Any(account => account.Id == accountId)),
					orderBy: comment => comment.CreatedAt)
				.ToListAsync();
		}
	}
}