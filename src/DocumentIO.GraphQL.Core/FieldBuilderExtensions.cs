using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Builders;
using GraphQL.Types;
using GraphQL.Validation;
using Phema.Validation;

namespace DocumentIO
{
	public static class FieldBuilderExtensions
	{
		public static FieldBuilder<object, TReturnType> ResolveWithValidation<TArgumentType, TReturnType>(
			this FieldBuilder<object, TReturnType> builder,
			Func<ResolveFieldContext<object>, Task<TReturnType>> resolve)
		{
			return builder.ResolveAsync(async context =>
			{
				var serviceProvider = context.GetServiceProvider();
				var validationContext = context.GetValidationContext();

				foreach (var arguments in context.Arguments)
				{
					var value = arguments.Value as Dictionary<string, object>;
					var model = value.ToObject(typeof(TArgumentType));

					var validationType = typeof(IGraphQLValidation<>).MakeGenericType(model.GetType());

					var validation = serviceProvider.GetService(validationType);

					validationType.GetMethod("Validate", BindingFlags.Instance | BindingFlags.Public)
						.Invoke(validation, new[] {validationContext, model});
				}

				if (!validationContext.IsValid())
				{
					foreach (var (validationKey, validationMessage) in validationContext.ValidationDetails)
					{
						context.Errors.Add(new ValidationError(null, validationKey, validationMessage));
					}

					return default;
				}

				return await resolve(context);
			});
		}
	}
}