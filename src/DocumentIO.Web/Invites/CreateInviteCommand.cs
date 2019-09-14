using System;
using System.Threading.Tasks;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class CreateInviteCommand
	{
		public string Role { get; set;  }
		public string Email { get; set; }
		public string Description { get; set; }
		public DateTime? DueDate { get; set; }

		public void Validate(IValidationContext validationContext)
		{
			validationContext.When(this, i => i.Role)
				.IsNotIn(Roles.All)
				.AddError("Неизвестная роль");

			validationContext.When(this, i => i.Email)
				.IsNotEmail()
				.AddError("Некорректный email");

			validationContext.When(this, i => i.Description)
				.IsNullOrWhitespace()
				.AddError("Описание должно быть задано");
		}

		public async Task Create(DatabaseContext databaseContext, Company company)
		{
			var invite = new Invite
			{
				Role = Role,
				Email = Email,
				Identifier = Guid.NewGuid(),
				Description = Description,
				CreatedAt = DateTime.UtcNow,
				DueDate = DueDate,
				Company = company
			};

			await databaseContext.Invites.AddAsync(invite);
		}
	}
}