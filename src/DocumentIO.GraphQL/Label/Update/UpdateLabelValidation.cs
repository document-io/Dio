using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public class UpdateLabelValidation : IDocumentIOValidation
	{
		public Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			// TODO: Валидация
			// Карточка существует
			// Имя либо null, либо задано
			// Описание либо null, либо задано
			// Цвет либо null, либо задан #AABBCCDD

			return Task.CompletedTask;
		}
	}
}