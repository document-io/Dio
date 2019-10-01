using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CommentsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public CommentsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<CommentsFilter>();

			return filter.Filtered(
					databaseContext.CardComments.AsNoTracking(),
					comments => comments.Where(comment => comment
						.Account
						.Organization
						.Accounts
						.Any(account => account.Id == accountId)),
					comment => comment.CreatedAt)
				.CountAsync();
		}
	}
}