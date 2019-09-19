using System;
using System.Collections.Generic;
using System.Linq;
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
		public static FieldBuilder<TSourceType, TReturnType> ResolveWithValidation<TSourceType, TReturnType>(
			this FieldBuilder<TSourceType, TReturnType> builder,
			Func<ResolveFieldContext<TSourceType>, Task<TReturnType>> resolve)
		{
			return builder.ResolveAsync(async context =>
			{
				var serviceProvider = context.GetServiceProvider();
				var validationContext = context.GetValidationContext();

				for (var index = 0; index < context.Arguments.Count; index++)
				{
					var argument = context.Arguments.Values.ElementAt(index) as Dictionary<string, object>;
					var type = builder.FieldType.Arguments[index].ResolvedType switch
					{
						NonNullGraphType nngt => nngt.Type.BaseType.GetGenericArguments().FirstOrDefault(),
						GraphType gt => gt.GetType().BaseType.GetGenericArguments().FirstOrDefault(),
						_ => throw new InvalidOperationException()
					};

					if (type == null)
					{
						continue;
					}

					var model = argument.ToObject(type);
					var validationType = typeof(IGraphQLValidation<>).MakeGenericType(model.GetType());

					var validation = serviceProvider.GetService(validationType);

					if (validation == null)
					{
						continue;
					}

					await (Task) validationType
						.GetMethod("Validate", BindingFlags.Instance | BindingFlags.Public)
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