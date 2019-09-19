using System.Linq;
using GraphQL.Authorization;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class BoardsMutations
	{
		public static void AddBoardsMutations(this DocumentIOMutations mutations)
		{
			mutations.Field<ReadBoardGraphType, ReadBoardModel>("createBoard")
				.Argument<NonNullGraphType<CreateBoardGraphType>>("payload")
				.AuthorizeWith(Roles.User)
				.ResolveWithValidation(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();
					var model = context.GetArgument<CreateBoardModel>("payload");

					var board = await model.Create(databaseContext, accountId);

					await databaseContext.SaveChangesAsync();

					return new ReadBoardModel
					{
						Id = board.Id,
						OrganizationId = board.OrganizationId,
						Name = board.Name
					};
				});

			mutations.Field<ReadBoardGraphType, ReadBoardModel>("updateBoard")
				.Argument<NonNullGraphType<IntGraphType>>("id")
				.Argument<NonNullGraphType<UpdateBoardGraphType>>("payload")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();
					var boardId = context.GetArgument<int>("id");
					var model = context.GetArgument<UpdateBoardModel>("payload");

					var board = await model.Update(databaseContext, accountId, boardId);

					await databaseContext.SaveChangesAsync();

					return new ReadBoardModel
					{
						Id = board.Id,
						OrganizationId = board.OrganizationId,
						Name = board.Name
					};
				});
			
			mutations.Field<ReadBoardGraphType, ReadBoardModel>("deleteBoard")
				.Argument<NonNullGraphType<IntGraphType>>("id")
				.AuthorizeWith(Roles.Admin)
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var databaseContext = context.GetDatabaseContext();
					var boardId = context.GetArgument<int>("id");

					var board = await databaseContext.Boards
						.Where(x => x.Organization.Accounts.Any(u => u.Id == accountId))
						.SingleAsync(x => x.Id == boardId);

					return new ReadBoardModel
					{
						Id = board.Id,
						OrganizationId = board.OrganizationId,
						Name = board.Name
					};
				});
		}
	}
}