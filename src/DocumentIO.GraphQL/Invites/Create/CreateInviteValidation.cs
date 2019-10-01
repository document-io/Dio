using System.Threading.Tasks;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateInviteValidation : IDocumentIOValidation
	{
		public Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var model = context.GetArgument<Invite>();

			validationContext.When(model, m => m.Role)
				.IsNotIn(Roles.All)
				.AddValidationDetail("Неизвестная роль");

			validationContext.When(model, m => m.Description)
				.IsNullOrWhitespace()
				.AddValidationDetail("Заполните описание");

			return Task.CompletedTask;
		}
	}
}