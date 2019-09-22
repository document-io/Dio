using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateAccountResolver : IDocumentIOResolver<Account>
	{
		private readonly DatabaseContext databaseContext;

		public CreateAccountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Account> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var secret = context.GetArgument<Guid>("secret");
			var account = context.GetArgument<Account>();

			var invite = await databaseContext
				.Invites
				.SingleAsync(x => x.Secret == secret && x.AccountId == null);

			account.Role = invite.Role;
			account.CreatedAt = DateTime.UtcNow;
			account.Invite = invite;
			account.OrganizationId = invite.OrganizationId;

			await databaseContext.Accounts.AddAsync(account);

			await databaseContext.SaveChangesAsync();

			return account;
		}
	}
}