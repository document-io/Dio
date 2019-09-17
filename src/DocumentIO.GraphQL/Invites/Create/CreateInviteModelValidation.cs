using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateInviteModelValidation : IGraphQLValidation<CreateInviteModel>
	{
		private readonly DatabaseContext databaseContext;

		public CreateInviteModelValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(IValidationContext validationContext, CreateInviteModel model)
		{
			validationContext.When(model, m => m.Role)
				.IsNotIn(Roles.All)
				.AddError("Задана некорректная роль");

			validationContext.When(model, m => m.Email)
				.IsNotEmail()
				.AddError("Некорректный email");

			validationContext.When(model, m => m.Description)
				.IsNullOrWhitespace()
				.AddError("Описание не задано");

			validationContext.When(model, m => m.DueDate)
				.IsNotNull()
				.Is(value => value < DateTime.UtcNow.AddMinutes(10))
				.AddError("Минимальное время жизни приглашения 10 минут");

			if (validationContext.IsValid(model, m => m.Email))
			{
				var inviteExists = await databaseContext.Invites
					.AnyAsync(x => x.Email == model.Email);

				validationContext.When(model, m => m.Email)
					.Is(() => inviteExists)
					.AddError("Приглашение уже было создано, либо пользователь находится в другой организации");
			}
		}
	}
}