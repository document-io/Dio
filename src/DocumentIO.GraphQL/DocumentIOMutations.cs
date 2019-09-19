using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class OrganizationType : ObjectGraphType<Organization>
	{
		public OrganizationType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Name, nullable: true);

			Field<ReadOrganizationType, Organization>("create")
				.Argument<CreateOrganizationType>("payload")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var organization = context.GetArgument<Organization>("payload");

					await databaseContext.Database.BeginTransactionAsync();
					
					await context.GetDatabaseContext().Organizations.AddAsync(organization);

					databaseContext.Database.CommitTransaction();
					await databaseContext.SaveChangesAsync();

					return organization;
				});
		}
	}

	public class CreateOrganizationType : InputObjectGraphType<Organization>
	{
		public CreateOrganizationType()
		{
			Field(x => x.Name);

			Field<CreateAccountType, Account>("account")
				.Argument<CreateAccountType>("payload")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var account = context.GetArgument<Account>("payload");

					await databaseContext.Database.BeginTransactionAsync();

					account.OrganizationId = context.Source.Id;
					await databaseContext.Accounts.AddAsync(account);

					databaseContext.Database.CommitTransaction();
					await databaseContext.SaveChangesAsync();

					return account;
				});
		}
	}

	public class ReadAccountType : ObjectGraphType<Account>
	{
		public ReadAccountType()
		{
			Field(x => x.Id);
			Field(x => x.Email);
			Field(x => x.Role);
		}
	}
	
	public class CreateAccountType : InputObjectGraphType<Account>
	{
		public CreateAccountType()
		{
			Field(x => x.Email);
			Field(x => x.Role);
		}
	}
	
	public class ReadOrganizationType : ObjectGraphType<Organization>
	{
		public ReadOrganizationType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);

			Field<ListGraphType<ReadAccountType>, IEnumerable<Account>>("accounts")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, Account>(
						"OrganizationAccounts",
						async ids => await databaseContext.Accounts
							.Where(x => ids.Contains(x.OrganizationId))
							.ToListAsync(),
						x => x.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}

	public class DocumentIOMutations : ObjectGraphType
	{
		public DocumentIOMutations()
		{
			Name = "Mutation";

			Field<OrganizationType, Organization>("organizations")
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();

					var organization = await databaseContext.Organizations
						.Where(x => x.Accounts.Any(account => account.Id == accountId))
						.SingleOrDefaultAsync();

					return organization ?? new Organization();
				});

			this.AddOrganizationMutations();
			this.AddInviteMutations();
			this.AddAccountMutations();
			this.AddBoardsMutations();
			this.AddColumnMutations();
		}
	}
}