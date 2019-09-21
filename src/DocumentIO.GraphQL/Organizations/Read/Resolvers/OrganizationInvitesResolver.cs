using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class OrganizationInvitesResolver : IDocumentIOResolver<Organization, IEnumerable<Invite>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public OrganizationInvitesResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public Task<IEnumerable<Invite>> Resolve(DocumentIOResolveFieldContext<Organization> context)
		{
			var filter = context.GetFilter<InviteFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Invite>(
				"OrganizationInvites",
				async ids =>
					await filter.Filtered(
							databaseContext.Invites.AsNoTracking(),
							invites => invites.Where(invite => ids.Contains(invite.OrganizationId)))
						.ToListAsync(),
				invite => invite.OrganizationId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}