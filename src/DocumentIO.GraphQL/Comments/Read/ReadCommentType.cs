using System;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadCommentType : ObjectGraphType<CardComment>
	{
		public ReadCommentType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Content);
			Field(x => x.CreatedAt);

			Field<ReadCardType, Card>("card")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Card>(
						"CommentCard",
						async ids => await databaseContext.CardComments
							.Include(assignment => assignment.Card)
							.Where(assignment => ids.Contains(assignment.CardId))
							.ToDictionaryAsync(x => x.CardId, x => x.Card));

					return loader.LoadAsync(context.Source.CardId);
				});

			Field<ReadAccountType, Account>("account")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Account>(
						"CommentAccount",
						async ids => await databaseContext.CardComments
							.Include(assignment => assignment.Account)
							.Where(assignment => ids.Contains(assignment.AccountId))
							.ToDictionaryAsync(x => x.AccountId, x => x.Account));

					return loader.LoadAsync(context.Source.AccountId);
				});
		}
	}
}