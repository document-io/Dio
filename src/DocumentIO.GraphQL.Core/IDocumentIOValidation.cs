using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public interface IDocumentIOValidation
	{
	}

	public interface IDocumentIOValidation<TSourceType> : IDocumentIOValidation
	{
		Task Validate(DocumentIOResolveFieldContext<TSourceType> context, IValidationContext validationContext);
	}
}