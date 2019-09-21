using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Authorization;
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

		public DocumentIOFieldBuilder<TSourceType, TReturnType> Authorize(string role)
		{
			// TODO: AllowAdmin, AllowUser???
			builder.AuthorizeWith(role);

			return this;
		}

		public DocumentIOFieldBuilder<TSourceType, TReturnType> Argument<TArgumentType>(
			string name = "input",
			string description = null)
			where TArgumentType : GraphType
		{
			builder.Argument<TArgumentType>(name, description);

			return this;
		}

		public DocumentIOFieldBuilder<TSourceType, TReturnType> NonNullArgument<TArgumentType>(
			string name = "input",
			string description = null)
			where TArgumentType : GraphType
		{
			return Argument<NonNullGraphType<TArgumentType>>(name, description);
		}

		public DocumentIOFieldBuilder<TSourceType, TReturnType> Argument<TArgumentType, TValidationType>(
			string name = "input",
			string description = null)
			where TArgumentType : GraphType
			where TValidationType : IDocumentIOValidation
		{
			builder.Argument<TArgumentType>(
				name,
				description,
				argument => argument.WithMetadata("validation", typeof(TValidationType)));

			return this;
		}

		public DocumentIOFieldBuilder<TSourceType, TReturnType> NonNullArgument<TArgumentType, TValidationType>(
			string name = "input",
			string description = null)
			where TArgumentType : GraphType
			where TValidationType : IDocumentIOValidation
		{
			return Argument<NonNullGraphType<TArgumentType>, TValidationType>(name, description);
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
			where TResolver : IDocumentIOResolver<TSourceType, TReturnType>
		{
			builder.ResolveAsync(async context =>
			{
				var serviceProvider = context.GetServiceProvider();
				var validationContext = context.GetValidationContext();

				await EnsureArgumentsValid(context, serviceProvider, validationContext);

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

		private async Task EnsureArgumentsValid(
			ResolveFieldContext<TSourceType> context,
			IServiceProvider serviceProvider,
			IValidationContext validationContext)
		{
			for (var index = 0; index < context.Arguments?.Count; index++)
			{
				var validationType = builder.FieldType.Arguments[index].GetMetadata<Type>("validation");

				if (validationType == null)
				{
					continue;
				}

				var type = validationType.GetInterfaces().First().GenericTypeArguments[1];

				if (type == null)
				{
					continue;
				}

				var argument = context.Arguments.Values.ElementAt(index) as Dictionary<string, object>;

				var model = argument.ToObject(type);

				var validation = serviceProvider.GetService(validationType);

				if (validation == null)
				{
					continue;
				}

				await (Task) validationType
					.GetMethod("Validate", BindingFlags.Instance | BindingFlags.Public)
					.Invoke(validation, new[] { validationContext, model });
			}
		}
	}
}