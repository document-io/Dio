using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class LoginAccountResolver : IDocumentIOResolver<Account>
	{
		private readonly DatabaseContext databaseContext;

		public LoginAccountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Account> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var httpContext = context.GetHttpContext();
			var input = context.GetArgument<Account>();

			var account = await databaseContext
				.Accounts
				.SingleAsync(x => x.Email == input.Email);

			await httpContext.SignInAsync(
				CookieAuthenticationDefaults.AuthenticationScheme,
				new ClaimsPrincipal(new ClaimsIdentity(new[]
				{
					new Claim(ClaimTypes.Name, account.Id.ToString()),
					new Claim(ClaimTypes.Role, account.Role) 
				})));

			return account;
		}
	}
}