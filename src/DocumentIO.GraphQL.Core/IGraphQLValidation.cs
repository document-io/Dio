using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public interface IGraphQLValidation<TModel>
	{
		Task Validate(IValidationContext validationContext, TModel model);
	}
}