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

	public interface IDocumentIOResolver<TReturnType> : IDocumentIOResolver<object, TReturnType>
	{
	}
}