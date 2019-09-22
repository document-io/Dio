using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateCommentValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public CreateCommentValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<CardComment>();

			validationContext.When(model, m => m.Text)
				.IsNullOrWhitespace()
				.AddError("Пустой текст");

			var cardExists = await databaseContext.Cards
				.Where(x => x.Column.Board.Organization.Accounts.Any(a => a.Id == accountId))
				.AnyAsync(x => x.Id == model.CardId);

			validationContext.When(model, m => m.CardId)
				.IsNot(() => cardExists)
				.AddError("Карточка не найдена");
		}
	}
}