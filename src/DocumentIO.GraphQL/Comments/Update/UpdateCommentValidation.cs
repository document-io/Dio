using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class UpdateCommentValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public UpdateCommentValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var model = context.GetArgument<CardComment>();

			validationContext.When(model, m => m.Text)
				.IsNullOrWhitespace()
				.AddValidationDetail("Текст пустой");

			var comment = await databaseContext.CardComments
				.FirstOrDefaultAsync(x => x.Id == model.Id && x.AccountId == accountId);

			validationContext.When(model, m => m.Id)
				.Is(() => comment == null)
				.AddValidationDetail("Комментарий не найден");

			if (comment != null)
			{
				validationContext.When()
					.Is(() => comment.CreatedAt.AddHours(1) < DateTime.UtcNow)
					.AddValidationDetail("Комментарий можно отредактировать только в первый час создания");
			}
		}
	}
}