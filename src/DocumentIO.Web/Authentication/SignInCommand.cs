using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class SignInCommand
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public async Task<Employee> Execute(
			DatabaseContext databaseContext,
			IValidationContext validationContext,
			IPasswordHasher<Employee> passwordHasher)
		{
			var employee = await databaseContext.Employees.FirstOrDefaultAsync(e => e.Email == Email);

			Validate(employee, validationContext, passwordHasher);

			return employee;
		}

		private void Validate(
			Employee employee,
			IValidationContext validationContext,
			IPasswordHasher<Employee> passwordHasher)
		{
			validationContext.When(this, c => c.Email)
				.IsNotEmail()
				.AddError("Это не email =(");

			validationContext.When(this, c => c.Password)
				.IsNullOrWhitespace()
				.AddError("Пароль не задан");

			if (validationContext.IsValid(this, c => c.Email, c => c.Password))
			{
				validationContext.When()
					.Is(() => employee == null
						|| passwordHasher.VerifyHashedPassword(employee, employee.PasswordHash, Password)
							!= PasswordVerificationResult.Success)
					.AddError("Пользователь не найден, либо пара email/пароль не совпадает");
			}
		}
	}
}