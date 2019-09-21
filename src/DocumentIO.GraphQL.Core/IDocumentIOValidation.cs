using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public interface IDocumentIOValidation
	{
		Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext);
	}
}