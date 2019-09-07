using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Phema.Validation;

namespace DocumentIO.Web
{
	[Route("authentication")]
	public class AuthenticationController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IValidationContext validationContext;
		private readonly IPasswordHasher<Employee> passwordHasher;

		public AuthenticationController(
			DatabaseContext databaseContext,
			IValidationContext validationContext,
			IPasswordHasher<Employee> passwordHasher)
		{
			this.databaseContext = databaseContext;
			this.validationContext = validationContext;
			this.passwordHasher = passwordHasher;
		}

		[HttpPost("signup")]
		public async Task<ActionResult<ProblemDetails>> SignUp([FromBody] SignUpCommand command)
		{
			await command.Execute(databaseContext, validationContext, passwordHasher);

			if (validationContext.IsValid())
			{
				await databaseContext.SaveChangesAsync();

				return Ok();
			}

			return BadRequest(new ValidationProblemDetails(validationContext.FormatValidationDetails()));
		}

		[HttpPost("signin")]
		public async Task<ActionResult<ProblemDetails>> SignIn([FromBody] SignInCommand command)
		{
			var employee = await command.Execute(databaseContext, validationContext, passwordHasher);

			if (validationContext.IsValid())
			{
				await HttpContext.SignInAsync(
					new ClaimsPrincipal(
						new ClaimsIdentity(new[]
							{
								new Claim(ClaimTypes.Name, employee.Id.ToString())
							},
							CookieAuthenticationDefaults.AuthenticationScheme)));

				return Ok();
			}

			return BadRequest(new ValidationProblemDetails(validationContext.FormatValidationDetails()));
		}

		[Authorize]
		[HttpPost("signout")]
		public async Task SignOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
		}
	}
}