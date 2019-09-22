using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AccountCommentsResolver : IDocumentIOResolver<Account, IEnumerable<CardComment>>
	{
		private readonly IDataLoaderContextAccessor accessor;
		private readonly DatabaseContext databaseContext;

		public AccountCommentsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<IEnumerable<CardComment>> Resolve(DocumentIOResolveFieldContext<Account> context)
		{
			var filter = context.GetFilter<CommentsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardComment>(
				"AccountComments",
				async ids => 
					await filter.Filtered(
							databaseContext.CardComments.AsNoTracking(),
							comments => comments.Where(cardLabel => ids.Contains(cardLabel.AccountId)),
							comment => comment.CreatedAt)
						.ToListAsync(),
				cardLabel => cardLabel.AccountId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}