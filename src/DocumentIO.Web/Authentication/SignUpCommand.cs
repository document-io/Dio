using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class SignUpCommand
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }

		public async Task Execute(
			DatabaseContext databaseContext,
			IValidationContext validationContext,
			IPasswordHasher<Employee> passwordHasher)
		{
			Validate(databaseContext, validationContext);

			var employee = new Employee
			{
				Email = Email,
				FirstName = FirstName,
				MiddleName = MiddleName,
				LastName = LastName,
				CreatedAt = DateTime.UtcNow
			};

			if (validationContext.IsValid(this, c => c.Password))
			{
				employee.PasswordHash = passwordHasher.HashPassword(null, Password);
			}

			await databaseContext.Employees.AddAsync(employee);
		}

		private void Validate(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			validationContext.When(this, c => c.Email)
				.IsNotEmail()
				.AddError("Это не email =(");

			validationContext.When(this, c => c.Email)
				.Is(() => databaseContext.Employees.Any(e => e.Email == Email))
				.AddError("Email уже занят");

			validationContext.When(this, c => c.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");
			
			validationContext.When(this, c => c.FirstName)
				.IsNullOrWhitespace()
				.AddError("Имя не задано");

			validationContext.When(this, c => c.MiddleName)
				.IsNullOrWhitespace()
				.AddError("Отчество не задано");
			
			validationContext.When(this, c => c.LastName)
				.IsNullOrWhitespace()
				.AddError("Фамилия не задана");
		}
	}
}