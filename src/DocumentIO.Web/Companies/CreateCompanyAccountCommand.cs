using System;
using System.Linq;
using System.Threading.Tasks;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class CreateCompanyAccountCommand
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }

		public void Validate(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			validationContext.When(this, m => m.Email)
				.IsNotEmail()
				.AddError("Некорректный email");

			validationContext.When(this, m => m.Email)
				.Is(() => databaseContext.Accounts.Any(account => account.Email == Email))
				.AddError("Email уже занят");

			validationContext.When(this, m => m.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");

			validationContext.When(this, m => m.FirstName)
				.IsNullOrWhitespace()
				.AddError("Имя не задано");

			validationContext.When(this, m => m.LastName)
				.IsNullOrWhitespace()
				.AddError("Фамилия не задана");
		}
	
		public async Task Create(DatabaseContext databaseContext, Company company)
		{
			var invite = new Invite
			{
				Email = Email,
				Company = company,
				Role = Roles.Admin,
				CreatedAt = DateTime.UtcNow,
				Description = "Создание компании",
			};

			await databaseContext.Invites.AddAsync(invite);

			var account = new Account
			{
				Email = invite.Email,
				Role = invite.Role,
				FirstName = FirstName,
				MiddleName = MiddleName,
				LastName = LastName,
				// TODO: IPasswordHasher
				PasswordHash = Password,
				Invite = invite,
				CreatedAt = DateTime.UtcNow
			};

			await databaseContext.Accounts.AddAsync(account);
		}
	}
}