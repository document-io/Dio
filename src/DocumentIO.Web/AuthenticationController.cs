using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace DocumentIO.Web
{
	[Route("authentication")]
	public class AuthenticationController : ControllerBase
	{
		[HttpGet("signin")]
		public async Task<ActionResult> SignIn()
		{
			await HttpContext.SignInAsync(
				new ClaimsPrincipal(
					new ClaimsIdentity(
						new[]
						{
							new Claim(ClaimTypes.Name, "test"),
							new Claim(ClaimTypes.Role, "user")
						},
						CookieAuthenticationDefaults.AuthenticationScheme)));

			return Ok();
		}
	}
}