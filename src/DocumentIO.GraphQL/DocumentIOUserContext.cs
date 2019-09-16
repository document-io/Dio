using System;
using GraphQL.Authorization;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

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

		public IServiceProvider ServiceProvider => HttpContext.RequestServices;
	}
}