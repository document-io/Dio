using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DocumentIO
{
	public class CreateOrganizationResolver : IDocumentIOResolver<Organization>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IPasswordHasher<Account> passwordHasher;

		public CreateOrganizationResolver(DatabaseContext databaseContext, IPasswordHasher<Account> passwordHasher)
		{
			this.databaseContext = databaseContext;
			this.passwordHasher = passwordHasher;
		}

		public async Task<Organization> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var organization = context.GetArgument<Organization>();

			await databaseContext.Organizations.AddAsync(organization);

			foreach (var account in organization.Accounts)
			{
				var invite = new Invite
				{
					Role = Roles.Admin,
					Secret = Guid.NewGuid(),
					CreatedAt = DateTime.UtcNow,
					Description = "Создание организации",
					Organization = organization,
					Account = account
				};

				account.Role = invite.Role;
				account.CreatedAt = DateTime.UtcNow;
				account.Password = passwordHasher.HashPassword(account, account.Password);

				await databaseContext.Invites.AddAsync(invite);
			}

			await databaseContext.SaveChangesAsync();

			return organization;
		}
	}
}