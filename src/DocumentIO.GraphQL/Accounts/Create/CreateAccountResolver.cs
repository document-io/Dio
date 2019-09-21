using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateAccountResolver : IDocumentIOResolver<object, Account>
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

			var invite = await databaseContext.Invites
				.Include(x => x.Organization)
				.Where(x => x.Secret == secret)
				.SingleAsync(x => x.Account == null);

			account.Role = invite.Role;
			account.CreatedAt = DateTime.UtcNow;
			account.Invite = invite;
			account.Organization = invite.Organization;

			await databaseContext.Accounts.AddAsync(account);
			await databaseContext.SaveChangesAsync();

			return account;
		}
	}
}