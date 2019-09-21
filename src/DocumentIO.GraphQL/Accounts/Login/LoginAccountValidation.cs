using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class LoginAccountValidation : IDocumentIOValidation<object>
	{
		private readonly DatabaseContext databaseContext;

		public LoginAccountValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var model = context.GetArgument<Account>();

			validationContext.When(model, m => m.Email)
				.IsNotEmail()
				.AddError("Это не email =/");

			validationContext.When(model, m => m.Password)
				.IsNullOrWhitespace()
				.AddError("Укажите ваш пароль");

			if (validationContext.IsValid(model, m => m.Email) && validationContext.IsValid(model, m => m.Password))
			{
				var accountExists = await databaseContext.Accounts.AnyAsync(account =>
					account.Email == model.Email && account.Password == model.Password);

				validationContext.When()
					.IsNot(() => accountExists)
					.AddError("Email/пароль неверный, либо аккаунт не существует");
			}
		}
	}
}