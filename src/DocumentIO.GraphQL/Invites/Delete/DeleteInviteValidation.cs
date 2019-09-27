using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;

namespace DocumentIO
{
	public class DeleteInviteValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;

		public DeleteInviteValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
	
		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var accountId = context.GetAccountId();
			var inviteId = context.GetArgument<Guid>("id");

			var invite = await databaseContext
				.Invites
				.Where(x => x.Organization.Accounts.Any(account => account.Id == accountId))
				.FirstOrDefaultAsync(x => x.Id == inviteId);

			validationContext.When("id")
				.Is(() => invite == null)
				.AddValidationError("Приглашение не найдено");

			if (validationContext.IsValid("id"))
			{
				validationContext.When("id")
					.Is(() => invite.AccountId != null)
					.AddValidationError("Нельзя удалить использованное приглашение");
			}
		}
	}
}