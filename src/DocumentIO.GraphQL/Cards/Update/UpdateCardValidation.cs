using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class UpdateCardValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public UpdateCardValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Card>();

			var card = await ValidateCardExists(validationContext, model, accountId);

			await ValidateCardName(validationContext, card, model, accountId);
			await ValidateCardOrder(validationContext, card, model);

			if (model.ColumnId != Guid.Empty)
			{
				var columnExists = await databaseContext.Columns
					.AnyAsync(x => x.Board
						.Columns
						.Any(column => 
							column.Cards.Any(c => c == card)));

				validationContext.When(model, m => m.Id)
					.IsNot(() => columnExists)
					.AddValidationDetail("Колонка не найдена");
			}
		}

		public async Task<Card> ValidateCardExists(IValidationContext validationContext, Card model, Guid accountId)
		{
			var card = await databaseContext.Cards
				.Where(x => x.Column.Board.Organization.Accounts.Any(account => account.Id == accountId))
				.SingleOrDefaultAsync(x => x.Id == model.Id);

			validationContext.When(model, m => m.Id)
				.Is(() => card == null)
				.AddValidationDetail("Карточка не найдена");

			return card;
		}

		public async Task ValidateCardName(IValidationContext validationContext, Card card, Card model, Guid accountId)
		{
			validationContext.When(model, m => m.Name)
				.IsNullOrWhitespace()
				.AddValidationDetail("Укажите название карточки");

			if (validationContext.IsValid(model, m => m.Name) && validationContext.IsValid(model, m => m.Id))
			{
				var cardNameExists = await databaseContext.Boards
					.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId))
					.Where(x => x.Columns.Any(c => c.Id == card.ColumnId))
					.SelectMany(x => x.Columns)
					.SelectMany(x => x.Cards)
					.AnyAsync(x => x.Name == model.Name);

				validationContext.When(model, m => m.Name)
					.Is(() => cardNameExists)
					.AddValidationDetail("Карточка с таким названием уже существует");
			}
		}

		public async Task ValidateCardOrder(IValidationContext validationContext, Card card, Card model)
		{
			if (model.Order != 0)
			{
				validationContext.When(model, x => x.Order)
					.IsLess(0)
					.AddValidationDetail("Порядок не может быть меньше нуля");

				var cardsCount = await databaseContext
					.Columns
					.Where(x => x.Id == card.ColumnId)
					.SelectMany(x => x.Cards)
					.CountAsync();

				validationContext.When(model, m => m.Order)
					.IsGreater(cardsCount)
					.AddValidationDetail($"Порядок не может быть больше {cardsCount}");
			}
		}
	}
}