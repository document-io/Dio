using System;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace DocumentIO.Web
{
	public static class AuthenticationExtensions
	{
		public static IServiceCollection AddDocumentIOAuthentication(this IServiceCollection services)
		{
			services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
				.AddCookie(options =>
				{
					options.Events.OnRedirectToLogin = context =>
					{
						context.Response.StatusCode = 401;
						return Task.CompletedTask;
					};

					options.ExpireTimeSpan = TimeSpan.FromDays(7);
					options.SlidingExpiration = true;
					options.Cookie.HttpOnly = true;
				});

			services.AddSingleton<IPasswordHasher<Employee>, PasswordHasher<Employee>>();

			return services;
		}
	}
}