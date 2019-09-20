using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Builders;
using GraphQL.Types;
using GraphQL.Utilities;
using GraphQL.Validation;
using Phema.Validation;

namespace DocumentIO
{
	public class DocumentIOFieldBuilder<TSourceType, TReturnType>
	{
		private readonly FieldBuilder<TSourceType, TReturnType> builder;

		public DocumentIOFieldBuilder(FieldBuilder<TSourceType, TReturnType> builder)
		{
			this.builder = builder;
		}

		public DocumentIOFieldBuilder<TSourceType, TReturnType> Filtered<TFilterType>()
			where TFilterType : IComplexGraphType, new()
		{
			var filter = new TFilterType();

			builder.Configure(q =>
				{
					foreach (var field in filter.Fields)
					{
						q.Arguments.Add(new QueryArgument(field.Type)
						{
							Description = field.Description,
							Name = field.Name,
							DefaultValue = field.DefaultValue,
							Metadata = field.Metadata,
							ResolvedType = field.ResolvedType
						});
					}
				});

			return this;
		}

		public DocumentIOFieldBuilder<TSourceType, TReturnType> ResolveAsync<TResolver>()
			where TResolver : IGraphQLResolver<TSourceType, TReturnType>
		{
			builder.ResolveAsync(async context =>
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
						.Invoke(validation, new[] { validationContext, model });
				}

				if (!validationContext.IsValid())
				{
					foreach (var (validationKey, validationMessage) in validationContext.ValidationDetails)
					{
						context.Errors.Add(new ValidationError(null, validationKey, validationMessage));
					}

					return default;
				}

				return await serviceProvider.GetRequiredService<TResolver>()
					.Resolve(new DocumentIOResolveFieldContext<TSourceType>(context));
			});

			return this;
		}
	}
}