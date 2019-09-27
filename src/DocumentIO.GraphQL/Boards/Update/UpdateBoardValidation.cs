using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class UpdateBoardValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public UpdateBoardValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Board>();

			var boardExists = await databaseContext.Boards
				.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId))
				.AnyAsync(x => x.Id == model.Id);

			validationContext.When(model, m => m.Id)
				.IsNot(() => boardExists)
				.AddValidationError("Доска не найдена");

			validationContext.When(model, m => m.Name)
				.IsWhitespace()
				.AddValidationError("Название доски не задано");
		}
	}
}