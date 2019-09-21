using System.Threading.Tasks;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateInviteValidation : IDocumentIOValidation<object>
	{
		public Task Validate(DocumentIOResolveFieldContext<object> context, IValidationContext validationContext)
		{
			var model = context.GetArgument<Invite>();

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