using System.Threading.Tasks;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateInviteValidation : IDocumentIOValidation<CreateInviteType, Invite>
	{
		public Task Validate(IValidationContext validationContext, Invite model)
		{
			validationContext.When(model, m => m.Role)
				.IsNotIn(Roles.All)
				.AddError("Неизвестная роль");

			validationContext.When(model, m => m.Description)
				.IsNullOrWhitespace()
				.AddError("Заполните описание");

			return Task.CompletedTask;
		}
	}
}