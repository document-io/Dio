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

			var account = context.GetArgument<Account>("account");
			account.Role = Roles.Admin;
			account.CreatedAt = DateTime.UtcNow;
			account.Organization = organization;

			var invite = new Invite
			{
				Role = Roles.Admin,
				Secret = Guid.NewGuid(),
				CreatedAt = DateTime.UtcNow,
				Description = "Создание организации",
				Account = account,
				Organization = organization
			};

			await databaseContext.Organizations.AddAsync(organization);
			await databaseContext.Accounts.AddAsync(account);
			await databaseContext.Invites.AddAsync(invite);

			await databaseContext.SaveChangesAsync();

			return organization;
		}
	}
}