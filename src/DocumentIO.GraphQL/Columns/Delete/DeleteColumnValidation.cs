using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;

namespace DocumentIO
{
	public class DeleteColumnValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public DeleteColumnValidation(DatabaseContext databaseContext)
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

			validationContext.When()
				.IsNot(() => columnExists)
				.AddValidationDetail("Колонка не существует");

			if (validationContext.IsValid())
			{
				var hasColumns = await databaseContext
					.Columns
					.Where(x => x.Id == model.Id)
					.Where(x => x.Cards.Any())
					.AnyAsync();

				validationContext.When()
					.Is(() => hasColumns)
					.AddValidationDetail("Колонка содержит карточки");
			}
		}
	}
}