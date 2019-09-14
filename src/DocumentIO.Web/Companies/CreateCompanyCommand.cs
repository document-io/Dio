using System.Threading.Tasks;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class CreateCompanyCommand
	{
		public string Name { get; set; }
		public CreateCompanyAccountCommand Account { get; set; }

		public void Validate(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			validationContext.When(this, m => m.Name)
				.IsNullOrWhitespace()
				.AddError("Название компании не задано");

			Account.Validate(databaseContext, validationContext);
		}
	
		public async Task Create(DatabaseContext databaseContext)
		{
			var company = new Company
			{
				Name = Name
			};

			await databaseContext.Companies.AddAsync(company);

			await Account.Create(databaseContext, company);
		}
	}
}