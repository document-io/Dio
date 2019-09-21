using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO.Web
{
	public static class AuthenticationExtensions
	{
		public static IServiceCollection AddDocumentIOAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(o =>
				{
					o.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
					o.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
					o.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
					o.DefaultForbidScheme = CookieAuthenticationDefaults.AuthenticationScheme;

					o.RequireAuthenticatedSignIn = false;
				})
				.AddCookie(options =>
				{
					options.Events.OnRedirectToLogin = context =>
					{
						context.Response.StatusCode = 401;
						return Task.CompletedTask;
					};
					options.Cookie.Name = "DocumentIO";
					options.Cookie.HttpOnly = true;
					options.SlidingExpiration = true;
					options.ExpireTimeSpan = TimeSpan.FromDays(7);
				});

			return services;
		}
	}
}