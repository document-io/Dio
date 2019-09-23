using System.Threading.Tasks;
using Phema.Validation;

namespace DocumentIO
{
	public class CreateLabelValidation : IDocumentIOValidation
	{
		public Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			// TODO: Валидация
			// Доска существует
			// На доске еще нет такого лейбла
			// Описание либо null, либо не пустое
			// Цвет в формате #AABBCCDD

			return Task.CompletedTask;
		}
	}
}