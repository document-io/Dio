using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteInviteResolver : IDocumentIOResolver<Invite>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteInviteResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Invite> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var inviteId = context.GetArgument<Guid>("id");

			var invite = await databaseContext
				.Invites
				.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId))
				.SingleAsync(x => x.Id == inviteId && x.Account == null);

			databaseContext.Invites.Remove(invite);

			await databaseContext.SaveChangesAsync();

			return invite;
		}
	}
}