using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class SignInAccountCommand
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public void Validate(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			validationContext.When(this, a => a.Email)
				.IsNotEmail()
				.AddError("Некорректный email");

			validationContext.When(this, a => a.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не указан");

			if (validationContext.IsValid(this, a => a.Email, a => a.Password))
			{
				validationContext.When()
					.Is(() => databaseContext.Accounts
						// TODO: IPasswordHasher
						.Any(account => account.Email == Email && account.PasswordHash == Password))
					.AddError("Аккаунт не найден");
			}
		}

		public async Task Login(DatabaseContext databaseContext, HttpContext httpContext)
		{
			var account = await databaseContext.Accounts.FirstAsync(a => a.Email == Email);
			
			await httpContext.SignInAsync(
				new ClaimsPrincipal(
					new ClaimsIdentity(
						new[]
						{
							new Claim(ClaimTypes.Name, account.Id.ToString()),
							new Claim(ClaimTypes.Role, account.Role)
						},
						CookieAuthenticationDefaults.AuthenticationScheme)));
		}
	}
}