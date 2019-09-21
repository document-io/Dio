using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateAccountValidation : IDocumentIOValidation<object>
	{
		private readonly DatabaseContext databaseContext;

		public CreateAccountValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var model = context.GetArgument<Account>();
			var secret = context.GetArgument<Guid>("secret");

			var inviteExists = await databaseContext.Invites
				.Where(x => x.Secret == secret)
				.AnyAsync(x => x.Account == null);

			validationContext.When("secret")
				.IsNot(() => inviteExists)
				.AddError("Приглашение не найдено, либо уже использовано");

			await Validate(validationContext, model);
		}

		public async Task Validate(IValidationContext validationContext, Account model)
		{
			validationContext.When(model, m => m.Email)
				.IsNotEmail()
				.AddError("Это не email =/");

			validationContext.When(model, m => m.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");

			validationContext.When(model, m => m.FirstName)
				.IsNullOrWhitespace()
				.AddError("Имя не задано");

			validationContext.When(model, m => m.LastName)
				.IsNullOrWhitespace()
				.AddError("Фамилия не задана");

			if (validationContext.IsValid(model, m => m.Email))
			{
				var accountExists = await databaseContext.Accounts
					.AnyAsync(account => account.Email == model.Email);

				validationContext.When(model, m => m.Email)
					.Is(() => accountExists)
					.AddError("Email уже используется");
			}
		}
	}
}