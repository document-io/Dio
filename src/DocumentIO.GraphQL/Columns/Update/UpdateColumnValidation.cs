using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class UpdateColumnValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public UpdateColumnValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Column>();

			var columnExists = await databaseContext
				.Columns
				.Include(x => x.Board)
				.Where(x => x.Board.Organization.Accounts.Any(account => account.Id == accountId))
				.AnyAsync(x => x.Id == model.Id);

			validationContext.When(model, m => m.Id)
				.IsNot(() => columnExists)
				.AddValidationDetail("Колонка не найдена");

			validationContext.When(model, m => m.Name)
				.IsWhitespace()
				.AddValidationDetail("Имя колонки не указано");

			if (validationContext.IsValid(model, m => m.Name) && model.Name != null)
			{
				var columnNameExists = await databaseContext
					.Columns
					.Where(x => x.Board.Organization.Accounts.Any(account => account.Id == accountId))
					.AnyAsync(x => x.Name == model.Name);

				validationContext.When(model, m => m.Name)
					.Is(() => columnNameExists)
					.AddValidationDetail($"Колонка с именем '{model.Name}' уже сущетсвует");
			}

			if (model.Order != 0)
			{
				validationContext.When(model, x => x.Order)
					.IsLess(0)
					.AddValidationDetail("Порядок не может быть меньше нуля");

				var columnsCount = await databaseContext
					.Columns
					.Where(x => x.Board.Organization.Accounts.Any(account => account.Id == accountId))
					.CountAsync(x => x.Board.Columns.Any(c => c.Id == model.Id));

				validationContext.When(model, m => m.Order)
					.IsGreater(columnsCount)
					.AddValidationDetail($"Порядок не может быть больше {columnsCount}");
			}
		}
	}
}