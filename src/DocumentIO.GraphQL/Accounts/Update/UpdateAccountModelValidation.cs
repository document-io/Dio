using System.Threading.Tasks;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class UpdateAccountModelValidation : IGraphQLValidation<UpdateAccountModel>
	{
		public Task Validate(IValidationContext validationContext, UpdateAccountModel model)
		{
			validationContext.When(model, m => m.Email)
				.IsNotNull()
				.IsNotEmail()
				.AddError("Некорректный email");

			validationContext.When(model, m => m.Password)
				.IsNotNull()
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");

			validationContext.When(model, m => m.FirstName)
				.IsNotNull()
				.IsNullOrWhitespace()
				.AddError("Имя не задано");
			
			validationContext.When(model, m => m.MiddleName)
				.IsNotNull()
				.IsNullOrWhitespace()
				.AddError("Отчество не задано");
			
			validationContext.When(model, m => m.LastName)
				.IsNotNull()
				.IsNullOrWhitespace()
				.AddError("Фамилия не задана");
			
			return Task.CompletedTask;
		}
	}
}