using System;
using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateInviteResolver : IDocumentIOResolver<Invite>
	{
		private readonly DatabaseContext databaseContext;

		public CreateInviteResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Invite> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var invite = context.GetArgument<Invite>();

			var organization = await databaseContext.Organizations.GetByAccountId(accountId);

			invite.Secret = Guid.NewGuid();
			invite.CreatedAt = DateTime.UtcNow;
			invite.Organization = organization;

			await databaseContext.Invites.AddAsync(invite);
			await databaseContext.SaveChangesAsync();

			return invite;
		}
	}
}