using GraphQL.Types;

namespace DocumentIO
{
	public static class UserContextExtensions
	{
		public static DocumentIOUserContext GetUserContext<TSource>(this ResolveFieldContext<TSource> context)
		{
			return (DocumentIOUserContext) context.UserContext;
		}
	}
}