using System.Collections.Generic;
using System.Linq;
using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
    public static class AccountQueries
    {
        public static void AddAccountQueries(this DocumentIOQueries queries)
        {
            queries.Field<ReadAccountGraphType, ReadAccountModel>()
                .Name("getAccount")
                .AuthorizeWith(Roles.User)
                .Argument<IntGraphType>("id")
                .ResolveAsync(async context =>
                {
                    var accountId = context.GetAccountId();
                    var databaseContext = context.GetDatabaseContext();

                    var id = context.GetArgument<int?>("id");

                    var account = id == null
                        ? await databaseContext.Accounts.SingleAsync(x => x.Id == accountId)
                        : await databaseContext.Accounts
                            .Where(x => x.Organization.Accounts.Any(a => a.Id == accountId))
                            .SingleAsync(x => x.Id == id);

                    return new ReadAccountModel
                    {
                        Email = account.Email,
                        Id = account.Id,
                        CreatedAt = account.CreatedAt,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        MiddleName = account.MiddleName
                    };
                });

            queries.Field<ListGraphType<ReadAccountGraphType>, List<ReadAccountModel>>()
                .Name("getAccounts")
                .AuthorizeWith(Roles.User)
                .ResolveAsync(async context =>
                {
                    var accountId = context.GetAccountId();
                    var databaseContext = context.GetDatabaseContext();

                    var organization = await databaseContext.Organizations
                        .Include(x => x.Accounts)
                        .SingleAsync(x => x.Accounts.Any(a => a.Id == accountId));

                    return organization.Accounts
                        .Select(x => new ReadAccountModel
                        {
                            Id = x.Id,
                            Email = x.Email,
                            CreatedAt = x.CreatedAt,
                            FirstName = x.FirstName,
                            LastName = x.LastName,
                            MiddleName = x.MiddleName
                        })
                        .ToList();
                });
        }
    }
    
    public static class AccountMutations
    {
        public static void AddAccountMutations(this DocumentIOMutations mutations)
        {
            mutations.Field<ReadAccountGraphType, ReadAccountModel>()
                .Name("createAccount")
                .Argument<CreateAccountGraphType>("payload")
                .ResolveAsync(async context =>
                {
                    var databaseContext = context.GetDatabaseContext();
                    var model = context.GetArgument<CreateAccountModel>("payload");

                    var account = await model.Create(databaseContext);

                    return new ReadAccountModel
                    {
                        Email = account.Email,
                        Id = account.Id,
                        CreatedAt = account.CreatedAt,
                        FirstName = account.FirstName,
                        LastName = account.LastName,
                        MiddleName = account.MiddleName
                    };
                });
        }
    }
}