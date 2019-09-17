using GraphQL.Types;
using GraphQL.Validation;
using Phema.Validation;

namespace DocumentIO
{
	public static class ValidationContextExtensions
	{
		public static void AddDetailsToGraphQLContext<TSource>(
			this IValidationContext validationContext,
			ResolveFieldContext<TSource> fieldContext)
		{
			foreach (var (validationKey, validationMessage) in validationContext.ValidationDetails)
			{
				fieldContext.Errors
					.Add(new ValidationError(null, validationKey, validationMessage));
			}
		}
	}
}