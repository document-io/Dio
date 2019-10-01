using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class InvitesCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public InvitesCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<InvitesFilter>();

			return filter.Filtered(
					databaseContext.Invites.AsNoTracking(),
					invites => invites.Where(invite => invite
						.Organization
						.Accounts
						.Any(account => account.Id == accountId)),
					invite => invite.CreatedAt)
				.CountAsync();
		}
	}
}