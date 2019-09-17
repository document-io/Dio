using System.Security.Claims;
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
			services.AddSingleton<ISchema, DocumentIOSchema>();

			services.AddGraphQL()
				.AddGraphTypes(typeof(DocumentIOSchema))
				.AddRelayGraphTypes()
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
	}
}