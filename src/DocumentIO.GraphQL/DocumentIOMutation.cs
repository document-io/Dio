using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO
{
	public class DocumentIOMutation : ObjectGraphType
	{
		public DocumentIOMutation()
		{
			Name = "Mutation";

			Field<ReadAccountGraphType, ReadAccountDto>()
				.Name("createAccount")
				.AuthorizeWith(Roles.User)
				.Argument<NonNullGraphType<CreateAccountGraphType>>("account")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetUserContext()
						.ServiceProvider
						.GetRequiredService<DatabaseContext>();

					var createAccount = context.GetArgument<CreateAccountDto>("account");

					var account = new Account
					{
						Email = createAccount.Email,
						Password = createAccount.Password + "Hash",
						FirstName = createAccount.FirstName,
						LastName = createAccount.LastName,
						MiddleName = createAccount.MiddleName
					};
					await databaseContext.Accounts.AddAsync(account);
					await databaseContext.SaveChangesAsync();

					return new ReadAccountDto
					{
						Id = account.Id,
						Email = account.Email,
						FirstName = account.FirstName,
						LastName = account.LastName,
						MiddleName = account.MiddleName
					};
				});

			Field<ReadAccountGraphType, ReadAccountDto>()
				.Name("updateAccount")
				.AuthorizeWith(Roles.User)
				.Argument<IntGraphType>("id")
				.Argument<NonNullGraphType<UpdateAccountGraphType>>("account")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetUserContext()
						.ServiceProvider
						.GetRequiredService<DatabaseContext>();

					var accountId = context.GetArgument<int>("id");
					var updateAccount = context.GetArgument<UpdateAccountDto>("account");

					var account = await databaseContext.Accounts.SingleAsync(a => a.Id == accountId);

					if (updateAccount.Email != null)
						account.Email = updateAccount.Email;

					if (updateAccount.Password != null)
						account.Password = updateAccount.Password;

					if (updateAccount.FirstName != null)
						account.FirstName = updateAccount.FirstName;

					if (updateAccount.MiddleName != null)
						account.MiddleName = updateAccount.MiddleName;

					if (updateAccount.LastName != null)
						account.LastName = updateAccount.LastName;

					await databaseContext.SaveChangesAsync();

					return new ReadAccountDto
					{
						Id = account.Id,
						Email = account.Email,
						FirstName = account.FirstName,
						MiddleName = account.MiddleName,
						LastName = account.LastName
					};
				});

			Field<DeleteAccountGraphType, DeleteAccountDto>()
				.Name("deleteAccount")
				.AuthorizeWith(Roles.Admin)
				.Argument<IntGraphType>("id")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetUserContext()
						.ServiceProvider
						.GetRequiredService<DatabaseContext>();

					var accountId = context.GetArgument<int>("id");

					var account = await databaseContext.Accounts.SingleAsync(a => a.Id == accountId);

					databaseContext.Accounts.Remove(account);

					await databaseContext.SaveChangesAsync();

					return new DeleteAccountDto
					{
						Id = account.Id
					};
				});
		}
	}
}