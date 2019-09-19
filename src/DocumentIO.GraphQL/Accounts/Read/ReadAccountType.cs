using System;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadAccountType : ObjectGraphType<Account>
	{
		public ReadAccountType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Role);
			Field(x => x.Email);
			Field(x => x.FirstName);
			Field(x => x.MiddleName);
			Field(x => x.LastName);
			Field(x => x.CreatedAt);

			Field<ReadInviteType, Invite>("invite")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Invite>(
						"AccountInvite",
						async ids => await databaseContext.Accounts
							.Include(account => account.Invite)
							.Where(account => ids.Contains(account.Id))
							.ToDictionaryAsync(account => account.Id, account => account.Invite));

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ReadOrganizationType, Organization>("organization")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Organization>(
						"AccountOrganization",
						async ids => await databaseContext.Accounts
							.Include(account => account.Organization)
							.Where(account => ids.Contains(account.Id))
							.ToDictionaryAsync(account => account.Id, account => account.Organization));

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}