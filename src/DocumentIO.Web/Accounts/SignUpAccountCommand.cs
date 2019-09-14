using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class SignUpAccountCommand
	{
		public Guid Identifier { get; set; }
		public string Password { get; set; }

		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }

		public void Validate(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			validationContext.When()
				.Is(() => databaseContext.Invites.Any(invite => invite.Identifier == Identifier && invite.Account == null))
				.AddError("Приглашение отсутствует, либо уже использовано");

			validationContext.When(this, a => a.FirstName)
				.IsNullOrWhitespace()
				.AddError("Имя не задано");

			validationContext.When(this, a => a.LastName)
				.IsNullOrWhitespace()
				.AddError("Фамилия не задана");

			validationContext.When(this, a => a.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");
		}

		public async Task SignUp(DatabaseContext databaseContext)
		{
			var invite = await databaseContext.Invites.FirstAsync(i => i.Identifier == Identifier);

			var account = new Account
			{
				Email = invite.Email,
				Role = invite.Role,
				CreatedAt = DateTime.UtcNow,
				FirstName = FirstName,
				MiddleName = MiddleName,
				LastName = LastName,
				Invite = invite,
				// TODO: IPasswordHasher
				PasswordHash = Password
			};

			await databaseContext.Accounts.AddAsync(account);
		}
	}
}