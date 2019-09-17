using System;
using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateOrganizationModel
	{
		public string Name { get; set; }

		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }

		public async Task<Organization> Create(DatabaseContext databaseContext)
		{
			var organization = new Organization
			{
				Name = Name
			};

			var account = new Account
			{
				Email = Email,
				Password = Password,
				FirstName = FirstName,
				MiddleName = MiddleName,
				LastName = LastName,
				CreatedAt = DateTime.UtcNow,
				Role = Roles.Admin,
				Organization = organization
			};

			var invite = new Invite
			{
				Identifier = Guid.NewGuid(),
				Description = "Создание организации",
				Email = Email,
				Role = Roles.Admin,
				CreatedAt = DateTime.UtcNow,
				Account = account,
				Organization = organization
			};

			await databaseContext.AddAsync(organization);
			await databaseContext.Accounts.AddAsync(account);
			await databaseContext.Invites.AddAsync(invite);

			return organization;
		}
	}
}