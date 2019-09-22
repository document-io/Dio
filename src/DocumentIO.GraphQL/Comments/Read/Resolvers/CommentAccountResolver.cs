using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CommentAccountResolver : IDocumentIOResolver<CardComment, Account>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public CommentAccountResolver(DatabaseContext databaseContext, IDataLoaderContextAccessor accessor)
		{
			this.databaseContext = databaseContext;
			this.accessor = accessor;
		}

		public Task<Account> Resolve(DocumentIOResolveFieldContext<CardComment> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Account>(
				"CommentAccount",
				async ids => await databaseContext.Accounts.AsNoTracking()
					.Where(x => ids.Contains(x.Id))
					.ToDictionaryAsync(x => x.Id));

			return loader.LoadAsync(context.Source.AccountId);
		}
	}
}