using System;
using GraphQL.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Phema.Validation;

namespace DocumentIO
{
	public class DocumentIOUserContext : Dictionary<string, object>, IProvideClaimsPrincipal
	{
		public DocumentIOUserContext(HttpContext httpContext)
		{
			HttpContext = httpContext;
		}

		public HttpContext HttpContext { get; }

		public ClaimsPrincipal User => HttpContext.User;

		public Guid AccountId => Guid.TryParse(User.Identity.Name, out var accountId) ? accountId : Guid.Empty;

		public IServiceProvider ServiceProvider => HttpContext.RequestServices;

		public DatabaseContext DatabaseContext => ServiceProvider.GetRequiredService<DatabaseContext>();

		public IValidationContext ValidationContext => ServiceProvider.GetRequiredService<IValidationContext>();
	}
}