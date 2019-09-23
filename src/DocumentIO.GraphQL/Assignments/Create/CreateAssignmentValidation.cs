using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;

namespace DocumentIO
{
	public class CreateAssignmentValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public CreateAssignmentValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<CardAssignment>();

			var accountExists = await databaseContext.Accounts
				.Where(x => x.Id == accountId)
				.Select(x => x.Organization)
				.SelectMany(x => x.Accounts)
				.AnyAsync(x => x.Id == model.AccountId);

			validationContext.When(model, m => m.AccountId)
				.IsNot(() => accountExists)
				.AddError("Аккаунт не найден");

			var cardExists = await databaseContext.Accounts
				.Where(x => x.Id == accountId)
				.Select(x => x.Organization)
				.SelectMany(x => x.Boards)
				.SelectMany(x => x.Columns)
				.SelectMany(x => x.Cards)
				.AnyAsync(x => x.Id == model.CardId);

			validationContext.When(model, m => m.AccountId)
				.IsNot(() => cardExists)
				.AddError("Карточка не найдена");

			if (validationContext.IsValid())
			{
				var assignmentExists = await databaseContext
					.CardAssignments
					.AnyAsync(x => x.AccountId == model.AccountId && x.CardId == model.CardId);

				validationContext.When()
					.Is(() => assignmentExists)
					.AddError("Аккаунт уже назначен");
			}
		}
	}
}