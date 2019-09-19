using System;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadEventType : ObjectGraphType<CardEvent>
	{
		public ReadEventType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Content);

			Field<ReadCardType, Card>("card")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Card>(
						"EventCard",
						async ids => await databaseContext.CardEvents
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
						"EventAccount",
						async ids => await databaseContext.CardEvents
							.Include(assignment => assignment.Account)
							.Where(assignment => ids.Contains(assignment.AccountId))
							.ToDictionaryAsync(x => x.AccountId, x => x.Account));

					return loader.LoadAsync(context.Source.AccountId);
				});
		}
	}
}