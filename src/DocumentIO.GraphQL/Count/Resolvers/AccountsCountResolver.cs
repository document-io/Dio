using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AccountsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public AccountsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<AccountFilter>();

			return filter.Filtered(
					databaseContext.Accounts.AsNoTracking(),
					accounts => accounts.Where(account => account.Organization.Accounts.Any(x => x.Id == accountId)),
					account => account.CreatedAt)
				.CountAsync();
		}
	}
}