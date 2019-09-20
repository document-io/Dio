using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class InviteOrganizationResolver : IGraphQLResolver<Invite, Organization>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public InviteOrganizationResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}

		public Task<Organization> Resolve(DocumentIOResolveFieldContext<Invite> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Organization>(
				"InviteOrganization",
				async ids => await databaseContext.Invites
					.AsNoTracking()
					.Include(invite => invite.Organization)
					.Where(invite => ids.Contains(invite.Id))
					.ToDictionaryAsync(invite => invite.Id, invite => invite.Organization));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}