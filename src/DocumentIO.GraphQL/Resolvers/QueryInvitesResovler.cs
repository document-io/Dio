using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryInvitesResovler : IDocumentIOResolver<object, IEnumerable<Invite>>
	{		
		private readonly DatabaseContext databaseContext;

		public QueryInvitesResovler(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Invite>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<InviteFilter>();

			var organization = await databaseContext.Organizations
				.AsNoTracking()
				.GetByAccountId(accountId);

			return await filter.Filtered(
					databaseContext.Invites.AsNoTracking(),
					invites => invites.Where(invite => invite.Organization == organization))
				.ToListAsync();
		}
	}
}