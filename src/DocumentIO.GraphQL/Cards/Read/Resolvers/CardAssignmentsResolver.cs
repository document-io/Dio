using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CardAssignmentsResolver : IDocumentIOResolver<Card, IEnumerable<Account>>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public CardAssignmentsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<Account>> Resolve(DocumentIOResolveFieldContext<Card> context)
		{
			var filter = context.GetFilter<AccountFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAssignment>(
				"CardAssignments",
				async ids => 
					await filter.Filtered(
							databaseContext.Accounts.AsNoTracking(),
							accounts => accounts.SelectMany(account => account.Assignments)
								.Include(cardLabel => cardLabel.Account)
								.Where(cardLabel => ids.Contains(cardLabel.CardId)))
						.ToListAsync(),
				cardLabel => cardLabel.CardId);

			var cardLabels = await loader.LoadAsync(context.Source.Id);

			return cardLabels.Select(cardLabel => cardLabel.Account).ToList();
		}
	}
}