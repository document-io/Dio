using GraphQL.Types;

namespace DocumentIO
{
	public static class UserContextExtensions
	{
		private static DocumentIOUserContext GetUserContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return (DocumentIOUserContext) context.UserContext;
		}

		public static int GetAccountId<TSource>(this ResolveFieldContext<TSource> context)
		{
			return context.GetUserContext().AccountId;
		}
		
		public static DatabaseContext GetDatabaseContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return context.GetUserContext().DatabaseContext;
		}
	}
}