using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateAccountModelValidation : IGraphQLValidation<CreateAccountModel>
	{
		private readonly DatabaseContext databaseContext;

		public CreateAccountModelValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(IValidationContext validationContext, CreateAccountModel model)
		{
			var hasActiveInvite = await databaseContext.Invites
				.AnyAsync(invite => invite.Identifier == model.Identifier && invite.AccountId == null);

			validationContext.When(model, m => m.Identifier)
				.IsNot(() => hasActiveInvite)
				.AddError("Приглашение отсутствует, либо уже использовано");

			validationContext.When(model, m => m.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");

			validationContext.When(model, m => m.FirstName)
				.IsNullOrWhitespace()
				.AddError("Имя не задано");

			validationContext.When(model, m => m.LastName)
				.IsNullOrWhitespace()
				.AddError("Фамилия не задана");
		}
	}
}