using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class LoginAccountValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;
		private readonly IPasswordHasher<Account> passwordHasher;

		public LoginAccountValidation(DatabaseContext databaseContext, IPasswordHasher<Account> passwordHasher)
		{
			this.databaseContext = databaseContext;
			this.passwordHasher = passwordHasher;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var model = context.GetArgument<Account>();

			validationContext.When(model, m => m.Email)
				.IsNotEmail()
				.AddValidationDetail("Это не email =/");

			validationContext.When(model, m => m.Password)
				.IsNullOrWhitespace()
				.AddValidationDetail("Укажите ваш пароль");

			if (validationContext.IsValid(model, m => m.Email) && validationContext.IsValid(model, m => m.Password))
			{
				var account = await databaseContext
					.Accounts
					.FirstOrDefaultAsync(x => x.Email == model.Email);

				var accountExists = account != null
					&& passwordHasher.VerifyHashedPassword(
						account,
						account.Password,
						model.Password) == PasswordVerificationResult.Success;

				validationContext.When()
					.IsNot(() => accountExists)
					.AddValidationDetail("Email/пароль неверный, либо аккаунт не существует");
			}
		}
	}
}