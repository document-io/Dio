using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateAccountResolver : IDocumentIOResolver<Account>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IPasswordHasher<Account> passwordHasher;

		public UpdateAccountResolver(DatabaseContext databaseContext, IPasswordHasher<Account> passwordHasher)
		{
			this.databaseContext = databaseContext;
			this.passwordHasher = passwordHasher;
		}

		public async Task<Account> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Account>();

			var account = await databaseContext.Accounts.SingleAsync(x => x.Id == accountId);

			if (model.Login != null)
			{
				account.Login = model.Login;
			}

			if (model.Email != null)
			{
				account.Email = model.Email;
			}

			if (model.Password != null)
			{
				account.Password = passwordHasher.HashPassword(account, model.Password);
			}

			if (model.FirstName != null)
			{
				account.FirstName = model.FirstName;
			}

			if (model.MiddleName != null)
			{
				account.MiddleName = model.MiddleName;
			}

			if (model.LastName != null)
			{
				account.LastName = model.LastName;
			}

			await databaseContext.SaveChangesAsync();

			return account;
		}
	}
}