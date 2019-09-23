using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public class DeleteCardLabelValidation : IDocumentIOValidation
	{
		public Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			// TODO: Валидация
			// Проверить что у этой организации есть эта карточка и лейбл передан с той самой доски
			// Проверить что CardLabel с такими id уже есть (чтобы его можно было удалить)

			return Task.CompletedTask;
		}
	}
}