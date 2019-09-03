using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DocumentIO.Web
{
	[Route("test")]
	public class TestController : ControllerBase
	{
		[HttpGet("signin")]
		public async Task<string> SignIn()
		{
			await HttpContext.SignInAsync(
				new ClaimsPrincipal(
					new ClaimsIdentity(new[]
					{
						new Claim(ClaimTypes.Name, "Test"),
					},
					CookieAuthenticationDefaults.AuthenticationScheme)));

			return "signin";
		}

		[Authorize]
		[HttpGet("signout")]
		public async Task<string> SignOut()
		{
			await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

			return "signout";
		}

		[Authorize]
		[HttpGet]
		public string Test()
		{
			return "Test: " + User.Identity.Name;
		}
	}
}