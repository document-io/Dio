using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class LoginAccountModel
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public async Task<Account> Login(DatabaseContext databaseContext, HttpContext httpContext)
		{
			var account = await databaseContext.Accounts
				.SingleAsync(x => x.Email == Email && x.Password == Password);

			await httpContext.SignInAsync(
				new ClaimsPrincipal(
					new ClaimsIdentity(
						new[]
						{
							new Claim(ClaimTypes.Name, account.Id.ToString()),
							new Claim(ClaimTypes.Role, account.Role)
						},
						CookieAuthenticationDefaults.AuthenticationScheme)));

			return account;
		}
	}
}