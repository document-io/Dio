using System.Linq;
using System.Reflection;
using System.Security.Claims;
using GraphQL;
using GraphQL.Authorization;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO.Web
{
	public static class GraphQLExtensions
	{
		public static IServiceCollection AddDocumentIOGraphQL(this IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			services.AddSingleton<ISchema, DocumentIOSchema>();
			services.AddSingleton<IDocumentExecuter, DocumentIODocumentExecuter>();

			var assembly = typeof(DocumentIOSchema).Assembly;
			
			services.AddGraphQL(options =>
				{
					options.ExposeExceptions = false;
				})
				.AddDataLoader()
				.AddGraphTypes(assembly)
				.AddGraphValidation(assembly)
				.AddGraphResolvers(assembly)
				.AddUserContextBuilder(context => new DocumentIOUserContext(context));

			return services;
		}

		public static IServiceCollection AddDocumentIOGraphQLAuthorization(this IServiceCollection services)
		{
			services.AddTransient<IValidationRule, AuthorizationValidationRule>();
			services.AddSingleton<IAuthorizationEvaluator, AuthorizationEvaluator>();

			services.AddSingleton(sp =>
			{
				var settings = new AuthorizationSettings();

				settings.AddPolicy(Roles.User,
					builder => builder.RequireClaim(ClaimTypes.Role, Roles.All));

				settings.AddPolicy(Roles.Admin,
					builder => builder.RequireClaim(ClaimTypes.Role, Roles.Admin));

				return settings;
			});

			return services;
		}

		public static IGraphQLBuilder AddGraphValidation(this IGraphQLBuilder builder, Assembly assembly)
		{
			var types = assembly.GetTypes()
				.Where(type => !type.IsAbstract
					// TODO: Возможно не будет работать и нужно указывать закрытый тип
					// Для этого сделать метод Argument<TArgument, TValidation>
					// Либо заиметь недженерик IGraphQLValidation и регистрировать (type.BaseType, type)
					&& typeof(IGraphQLValidation<>).IsAssignableFrom(type));

			foreach (var type in types)
			{
				builder.Services.Add(ServiceDescriptor.Scoped(type.BaseType, type));
			}

			return builder;
		}

		public static IGraphQLBuilder AddGraphResolvers(this IGraphQLBuilder builder, Assembly assembly)
		{
			var types = assembly.GetTypes()
				.Where(type => !type.IsAbstract
					&& typeof(IGraphQLResolver).IsAssignableFrom(type));

			foreach (var type in types)
			{
				builder.Services.Add(ServiceDescriptor.Scoped(type, type));
			}

			return builder;
		}
	}
}