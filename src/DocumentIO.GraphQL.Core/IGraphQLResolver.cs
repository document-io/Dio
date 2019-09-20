using System.Threading.Tasks;
using GraphQL.Types;

namespace DocumentIO
{
	public interface IGraphQLResolver
	{
	}

	public interface IGraphQLResolver<TSourceType, TReturnType> : IGraphQLResolver
	{
		Task<TReturnType> Resolve(DocumentIOResolveFieldContext<TSourceType> context);
	}
}