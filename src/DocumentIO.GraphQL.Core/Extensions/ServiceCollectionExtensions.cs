using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddGraphQLValidation<TModel, TValidation>(this IServiceCollection services)
			where TValidation : class, IGraphQLValidation<TModel>
		{
			return services.AddScoped<IGraphQLValidation<TModel>, TValidation>();
		}
	}
}