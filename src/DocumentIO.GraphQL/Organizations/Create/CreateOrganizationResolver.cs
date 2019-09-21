using System;
using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateOrganizationResolver : IDocumentIOResolver<object, Organization>
	{
		private readonly DatabaseContext databaseContext;

		public CreateOrganizationResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
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

				await databaseContext.Invites.AddAsync(invite);
			}

			await databaseContext.SaveChangesAsync();

			return organization;
		}
	}
}