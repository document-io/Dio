using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class LogoutAccountResolver : IDocumentIOResolver<Account>
	{
		private readonly DatabaseContext databaseContext;

		public LogoutAccountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Account> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var httpContext = context.GetHttpContext();

			var account = await databaseContext.Accounts
				.SingleAsync(x => x.Id == accountId);

			await httpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return account;
		}
	}
}