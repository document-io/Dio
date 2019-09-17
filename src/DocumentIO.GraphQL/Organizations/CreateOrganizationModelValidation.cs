using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateOrganizationModelValidation : IGraphQLValidation<CreateOrganizationModel>
	{
		private readonly DatabaseContext databaseContext;

		public CreateOrganizationModelValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(IValidationContext validationContext, CreateOrganizationModel model)
		{
			validationContext.When(model, x => x.Name)
				.IsNullOrWhitespace()
				.AddError("Укажите название организации");

			var organizationNameUsed = await databaseContext
				.Organizations
				.AnyAsync(x => x.Name == model.Name);

			validationContext.When(model, x => x.Name)
				.Is(() => organizationNameUsed)
				.AddError("Организация с таким именем уже занята");

			validationContext.When(model, x => x.Email)
				.IsNotEmail()
				.AddError("Неверный email");

			validationContext.When(model, x => x.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");

			validationContext.When(model, x => x.FirstName)
				.IsNullOrWhitespace()
				.AddError("Имя не задано");

			validationContext.When(model, x => x.LastName)
				.IsNullOrWhitespace()
				.AddError("Фамилия не задана");
		}
	}
}