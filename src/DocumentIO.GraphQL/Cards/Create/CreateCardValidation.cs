using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateCardValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public CreateCardValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Card>();

			await ValidateColumnExists(validationContext, model, accountId);
			await ValidateCardName(validationContext, model, accountId);

			validationContext.When(model, m => m.Description)
				.IsNullOrWhitespace()
				.AddValidationDetail("Описание не задано");
		}

		public async Task ValidateColumnExists(IValidationContext validationContext, Card model, Guid accountId)
		{
			var columnExists = await databaseContext.Columns
				.Where(x => x.Board.Organization.Accounts.Any(account => account.Id == accountId))
				.AnyAsync(x => x.Id == model.ColumnId);

			validationContext.When(model, m => m.ColumnId)
				.IsNot(() => columnExists)
				.AddValidationDetail("Колонка не найдена");
		}

		public async Task ValidateCardName(IValidationContext validationContext, Card model, Guid accountId)
		{
			validationContext.When(model, m => m.Name)
				.IsNullOrWhitespace()
				.AddValidationDetail("Укажите название карточки");

			if (validationContext.IsValid(model, m => m.Name))
			{
				var cardNameExists = await databaseContext.Boards
					.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId))
					.Where(x => x.Columns.Any(c => c.Id == model.ColumnId))
					.SelectMany(x => x.Columns)
					.SelectMany(x => x.Cards)
					.AnyAsync(x => x.Name == model.Name);

				validationContext.When(model, m => m.Name)
					.Is(() => cardNameExists)
					.AddValidationDetail("Карточка с таким названием уже существует");
			}
		}
	}
}