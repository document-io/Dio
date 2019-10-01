using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateAccountValidation : IDocumentIOValidation
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
				.AddValidationDetail("Приглашение не найдено, либо уже использовано");

			await ValidateAccount(validationContext, model);
		}

		public async Task ValidateAccount(IValidationContext validationContext, Account model)
		{
			var loginDetail = validationContext.When(model, m => m.Login)
				.IsNullOrWhitespace()
				.AddValidationDetail("Логин не задан");

			if (loginDetail is null)
			{
				var loginExists = await databaseContext
					.Accounts
					.AnyAsync(x => x.Login == model.Login);

				validationContext.When(model, m => m.Login)
					.Is(() => loginExists)
					.AddValidationDetail("Логин уже используется");
			}

			var emailDetail = validationContext.When(model, m => m.Email)
				.IsNotEmail()
				.AddValidationDetail("Это не email =/");

			if (emailDetail is null)
			{
				var accountExists = await databaseContext
					.Accounts
					.AnyAsync(account => account.Email == model.Email);

				validationContext.When(model, m => m.Email)
					.Is(() => accountExists)
					.AddValidationDetail("Email уже используется");
			}

			validationContext.When(model, m => m.Password)
				.IsNullOrWhitespace()
				.AddValidationDetail("Пароль не задан");

			validationContext.When(model, m => m.FirstName)
				.IsNullOrWhitespace()
				.AddValidationDetail("Имя не задано");

			validationContext.When(model, m => m.LastName)
				.IsNullOrWhitespace()
				.AddValidationDetail("Фамилия не задана");
		}
	}
}