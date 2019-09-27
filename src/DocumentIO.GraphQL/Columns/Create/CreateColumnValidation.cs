using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateColumnValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public CreateColumnValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Column>();

			var boardExists = await databaseContext
				.Boards
				.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId))
				.AnyAsync(x => x.Id == model.BoardId);

			validationContext.When(model, m => m.BoardId)
				.IsNot(() => boardExists)
				.AddValidationError("Доска не найдена");

			validationContext.When(model, m => m.Name)
				.IsNullOrWhitespace()
				.AddValidationError("Имя колонки не указано");

			if (validationContext.IsValid(model, m => m.Name))
			{
				var columnExists = await databaseContext
					.Columns
					.Where(x => x.Board.Organization.Accounts.Any(account => account.Id == accountId))
					.AnyAsync(x => x.Name == model.Name);

				validationContext.When(model, m => m.Name)
					.Is(() => columnExists)
					.AddValidationError("Колонка с таким именем уже сущетсвует");
			}
		}
	}
}