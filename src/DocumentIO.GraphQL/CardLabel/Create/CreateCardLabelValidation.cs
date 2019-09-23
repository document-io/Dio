using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public class CreateCardLabelValidation : IDocumentIOValidation
	{
		public Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			// TODO: Валидация
			// Проверить что у этой организации есть эта карточка и лейбл передан с той самой доски

			return Task.CompletedTask;
		}
	}
}