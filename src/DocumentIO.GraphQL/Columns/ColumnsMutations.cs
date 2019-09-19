using System.Linq;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class ColumnsMutations
	{
		public static void AddColumnMutations(this DocumentIOMutations mutations)
		{
			mutations.Field<ReadColumnGraphType, ReadColumnModel>("createColumn")
				.Argument<NonNullGraphType<IntGraphType>>("boardId")
				.Argument<NonNullGraphType<CreateColumnGraphType>>("payload")
				.ResolveWithValidation(async context =>
				{
					var accountId = context.GetAccountId();
					var boardId = context.GetArgument<int>("boardId");
					var model = context.GetArgument<CreateColumnModel>("payload");
					var databaseContext = context.GetDatabaseContext();

					// TODO: Унести в модель
					var board = await databaseContext.Boards
						.Where(x => x.Organization.Accounts.Any(u => u.Id == accountId))
						.SingleAsync(x => x.Id == boardId);

					var column = new Column
					{
						Board = board,
						Name = model.Name,
						Order = model.Order
					};

					await databaseContext.Columns.AddAsync(column);
					await databaseContext.SaveChangesAsync();

					return new ReadColumnModel
					{
						Id = column.Id,
						BoardId = column.BoardId,
						Name = column.Name,
						Order = column.Order
					};
				});

			mutations.Field<ReadColumnGraphType, ReadColumnModel>("updateColumn")
				.Argument<NonNullGraphType<IntGraphType>>("id")
				.Argument<NonNullGraphType<UpdateColumnGraphType>>("payload")
				.ResolveAsync(async context =>
				{
					var accountId = context.GetAccountId();
					var columnId = context.GetArgument<int>("id");
					var model = context.GetArgument<UpdateColumnModel>("payload");
					var databaseContext = context.GetDatabaseContext();

					// TODO: Унести в модель
					var column = await databaseContext.Columns
						.Where(x => x.Board.Organization.Accounts.Any(u => u.Id == accountId))
						.SingleAsync(x => x.Id == columnId);

					if (model.Name != null)
					{
						column.Name = model.Name;
					}

					if (model.Order != null)
					{
						column.Order = model.Order.Value;
					}

					await databaseContext.SaveChangesAsync();

					return new ReadColumnModel
					{
						Id = column.Id,
						BoardId = column.BoardId,
						Name = column.Name,
						Order = column.Order
					};
				});
		}
	}
}