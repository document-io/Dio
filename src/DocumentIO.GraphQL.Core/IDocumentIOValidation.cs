using System.Threading.Tasks;
using GraphQL.Types;
using Phema.Validation;

namespace DocumentIO
{
	public interface IDocumentIOValidation
	{
	}

	public interface IDocumentIOValidation<TGraphType, TModel> : IDocumentIOValidation
		where TGraphType : ComplexGraphType<TModel>
	{
		Task Validate(IValidationContext validationContext, TModel model);
	}
}