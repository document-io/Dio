using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;

namespace DocumentIO
{
	public class DeleteCommentValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCommentValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var id = context.GetArgument<Guid>("id");

			var comment = await databaseContext
				.CardComments
				.FirstOrDefaultAsync(x => x.Id == id && x.AccountId == accountId);

			validationContext.When("id")
				.Is(() => comment == null)
				.AddError("Комментарий не найден");

			if (comment != null)
			{
				validationContext.When()
					.Is(() => comment.CreatedAt.AddHours(1) < DateTime.UtcNow)
					.AddError("Комментарий можно удалить только в первый час создания");
			}
		}
	}
}