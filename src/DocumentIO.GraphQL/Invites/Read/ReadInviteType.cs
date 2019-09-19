using System;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadInviteType : ObjectGraphType<Invite>
	{
		public ReadInviteType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Secret);
			Field(x => x.Role);
			Field(x => x.Description);
			Field(x => x.CreatedAt);
			Field(x => x.DueDate, nullable: true);

			Field<ReadAccountType, Account>("account")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Account>(
						"InviteAccount",
						async ids => await databaseContext.Invites
							.Include(invite => invite.Account)
							.Where(invite => ids.Contains(invite.Id))
							.ToDictionaryAsync(invite => invite.Id, invite => invite.Account));

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ReadOrganizationType, Organization>("organization")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Organization>(
						"InviteOrganization",
						async ids => await databaseContext.Invites
							.Include(invite => invite.Organization)
							.Where(invite => ids.Contains(invite.Id))
							.ToDictionaryAsync(invite => invite.Id, invite => invite.Organization));

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}