using System;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Phema.Validation;

namespace DocumentIO
{
	public static class UserContextExtensions
	{
		private static DocumentIOUserContext GetUserContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return (DocumentIOUserContext)context.UserContext;
		}

		public static Guid GetAccountId<TSource>(this ResolveFieldContext<TSource> context)
		{
			var userContext = context.GetUserContext();

			return Guid.TryParse(userContext.User.Identity.Name, out var accountId)
				? accountId
				: Guid.Empty;
		}

		public static IValidationContext GetValidationContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			var userContext = context.GetUserContext();

			return userContext.ServiceProvider.GetRequiredService<IValidationContext>();
		}

		public static HttpContext GetHttpContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return context.GetUserContext().HttpContext;
		}

		public static IServiceProvider GetServiceProvider<TSource>(this ResolveFieldContext<TSource> context)
		{
			return context.GetUserContext().ServiceProvider;
		}
	}
}