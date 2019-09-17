using System;
using GraphQL.Types;
using Microsoft.AspNetCore.Http;
using Phema.Validation;

namespace DocumentIO
{
	public static class UserContextExtensions
	{
		private static DocumentIOUserContext GetUserContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return (DocumentIOUserContext)context.UserContext;
		}

		public static int GetAccountId<TSource>(this ResolveFieldContext<TSource> context)
		{
			return context.GetUserContext().AccountId;
		}

		public static DatabaseContext GetDatabaseContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return context.GetUserContext().DatabaseContext;
		}

		public static IValidationContext GetValidationContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return context.GetUserContext().ValidationContext;
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