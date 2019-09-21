using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateOrganizationValidation : IDocumentIOValidation<Organization>
	{
		private readonly DatabaseContext databaseContext;

		public CreateOrganizationValidation(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task Validate(IValidationContext validationContext, Organization model)
		{
			validationContext.When(model, m => m.Name)
				.IsNullOrWhitespace()
				.AddError("Задайте имя организации");

			if (validationContext.IsValid(model, m => m.Name))
			{
				var organizationNameExists = await databaseContext
					.Organizations
					.AnyAsync(organization => organization.Name == model.Name);

				validationContext.When(model, m => m.Name)
					.Is(() => organizationNameExists)
					.AddError("Имя организации уже используется");
			}
		}
	}
}