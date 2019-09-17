namespace DocumentIO
{
    public static class AccountMutations
    {
        public static void AddAccountMutations(this DocumentIOMutations mutations)
        {
            mutations.Field<ReadAccountGraphType, ReadAccountModel>()
                .Name("loginAccount")
                .Argument<LoginAccountGraphType>("payload")
                .ResolveAsync(async context =>
                {
                    var httpContext = context.GetHttpContext();
                    var databaseContext = context.GetDatabaseContext();
                    var model = context.GetArgument<LoginAccountModel>("payload");

                    var account = await model.Login(databaseContext, httpContext);

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