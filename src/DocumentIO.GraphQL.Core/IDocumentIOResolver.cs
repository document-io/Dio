using System.Threading.Tasks;

namespace DocumentIO
{
	public interface IDocumentIOResolver
	{
	}

	public interface IDocumentIOResolver<TSourceType, TReturnType> : IDocumentIOResolver
	{
		Task<TReturnType> Resolve(DocumentIOResolveFieldContext<TSourceType> context);
	}
}