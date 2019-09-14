using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phema.Validation;

namespace DocumentIO.Web
{
	[Route("accounts")]
	public class AccountsController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IValidationContext validationContext;

		public AccountsController(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			this.databaseContext = databaseContext;
			this.validationContext = validationContext;
		}

		[HttpPost("signup")]
		public async Task<ActionResult> SignUp([FromBody] SignUpAccountCommand command)
		{
			command.Validate(databaseContext, validationContext);

			if (!validationContext.IsValid())
			{
				return BadRequest(validationContext.Into());
			}

			await command.SignUp(databaseContext);

			await databaseContext.SaveChangesAsync();

			return Ok();
		}

		[HttpPost("signin")]
		public async Task<ActionResult> SignIn([FromBody] SignInAccountCommand command)
		{
			command.Validate(databaseContext, validationContext);

			if (!validationContext.IsValid())
			{
				return BadRequest(validationContext.Into());
			}

			await command.SignIn(databaseContext, HttpContext);

			return Ok();
		}

		[Authorize]
		[HttpPost("signout")]
		public async Task SignOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}
	}
}