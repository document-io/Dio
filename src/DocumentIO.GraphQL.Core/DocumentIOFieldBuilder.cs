using System;
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

		public DocumentIOFieldBuilder<TSourceType, TReturnType> Validate<TValidationType>()
			where TValidationType : IDocumentIOValidation
		{
			builder.Configure(q => q.WithMetadata("validation", typeof(TValidationType)));

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

		public DocumentIOFieldBuilder<TSourceType, TReturnType> DefaultValue(TReturnType value)
		{
			builder.DefaultValue(value);

			return this;
		}

		private async Task EnsureArgumentsValid(
			ResolveFieldContext<TSourceType> context,
			IServiceProvider serviceProvider,
			IValidationContext validationContext)
		{
			var validationType = builder.FieldType.GetMetadata<Type>("validation");

			if (validationType == null)
			{
				return;
			}

			var validation = serviceProvider.GetService(validationType);

			if (validation == null)
			{
				return;
			}

			await (Task) validationType
				.GetMethod("Validate", BindingFlags.Instance | BindingFlags.Public)
				.Invoke(validation, new object[]{ new DocumentIOResolveFieldContext<TSourceType>(context), validationContext });
		}
	}
}