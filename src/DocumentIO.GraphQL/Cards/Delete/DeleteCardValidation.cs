using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;

namespace DocumentIO
{
	public class DeleteCardValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCardValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<Card>();
			
			var card = await databaseContext.Cards
				.Where(x => x.Column.Board.Organization.Accounts.Any(account => account.Id == accountId))
				.SingleOrDefaultAsync(x => x.Id == model.Id);

			validationContext.When(model, m => m.Id)
				.Is(() => card == null)
				.AddValidationDetail("Карточка не найдена");
		}
	}
}