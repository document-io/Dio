using System.Linq;
using System.Reflection;
using System.Security.Claims;
using GraphQL;
using GraphQL.Authorization;
using GraphQL.Server;
using GraphQL.Types;
using GraphQL.Validation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DocumentIO.Web
{
	public static class GraphQLExtensions
	{
		public static IServiceCollection AddDocumentIOGraphQL(this IServiceCollection services, IWebHostEnvironment environment)
		{
			services.AddHttpContextAccessor();
			services.AddSingleton<ISchema, DocumentIOSchema>();
			services.AddSingleton<IDocumentExecuter, DocumentIODocumentExecuter>();

			services.AddSingleton<EnumerationGraphType<DocumentIOOrderBy>, DocumentIOOrderByType>();

			var assembly = typeof(DocumentIOSchema).Assembly;
			
			services.AddGraphQL(options =>
				{
					options.ExposeExceptions = environment.IsDevelopment();
					options.EnableMetrics = environment.IsDevelopment();
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
					&& typeof(IDocumentIOValidation).IsAssignableFrom(type));

			foreach (var type in types)
			{
				builder.Services.Add(ServiceDescriptor.Scoped(type, type));
			}

			return builder;
		}

		public static IGraphQLBuilder AddGraphResolvers(this IGraphQLBuilder builder, Assembly assembly)
		{
			var types = assembly.GetTypes()
				.Where(type => !type.IsAbstract
					&& typeof(IDocumentIOResolver).IsAssignableFrom(type));

			foreach (var type in types)
			{
				builder.Services.Add(ServiceDescriptor.Scoped(type, type));
			}

			return builder;
		}
	}
}