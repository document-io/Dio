using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateOrganizationValidation : IDocumentIOValidation
	{
		private readonly DatabaseContext databaseContext;
		private readonly CreateAccountValidation accountValidation;

		public CreateOrganizationValidation(
			DatabaseContext databaseContext,
			CreateAccountValidation accountValidation)
		{
			this.databaseContext = databaseContext;
			this.accountValidation = accountValidation;
		}

		public async Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var model = context.GetArgument<Organization>();
			
			validationContext.When(model, m => m.Name)
				.IsNullOrWhitespace()
				.AddValidationDetail("Задайте имя организации");

			if (validationContext.IsValid(model, m => m.Name))
			{
				var organizationNameExists = await databaseContext
					.Organizations
					.AnyAsync(organization => organization.Name == model.Name);

				validationContext.When(model, m => m.Name)
					.Is(() => organizationNameExists)
					.AddValidationDetail("Имя организации уже используется");
			}

			validationContext.When(model, m => m.Accounts)
				.IsEmpty()
				.AddValidationDetail("Создайте хотя-бы один аккаунт");

			for (var index = 0; index < model.Accounts.Count; index++)
			{
				var account = model.Accounts[index];

				using (var scope = validationContext.CreateScope(model, m => m.Accounts[index]))
				{
					await accountValidation.ValidateAccount(scope, account);
				}
			}
		}
	}
}