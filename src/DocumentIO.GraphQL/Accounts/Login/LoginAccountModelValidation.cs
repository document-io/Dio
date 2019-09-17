using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class LoginAccountModelValidation : IGraphQLValidation<LoginAccountModel>
	{
		private readonly DatabaseContext databaseContext;

		public LoginAccountModelValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(IValidationContext validationContext, LoginAccountModel model)
		{
			validationContext.When(model, m => m.Email)
				.IsNotEmail()
				.AddError("Некорректный email");

			validationContext.When(model, m => m.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");

			if (validationContext.IsValid(model, m => m.Email, m => m.Password))
			{
				var accountExists = await databaseContext
					.Accounts
					.AnyAsync(x => x.Email == model.Email && x.Password == model.Password);

				validationContext.When()
					.IsNot(() => accountExists)
					.AddError("Email или пароль неверный, либо аккаунт не существует");
			}
		}
	}
}