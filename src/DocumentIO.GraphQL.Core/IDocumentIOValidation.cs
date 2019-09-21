using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public interface IDocumentIOValidation
	{
	}

	public interface IDocumentIOValidation<TModel> : IDocumentIOValidation
	{
		Task Validate(IValidationContext validationContext, TModel model);
	}
}