using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AccountAssignmentsResolver : IGraphQLResolver<Account, IEnumerable<Card>>
	{
		private readonly IDataLoaderContextAccessor accessor;
		private readonly DatabaseContext databaseContext;

		public AccountAssignmentsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public async Task<IEnumerable<Card>> Resolve(DocumentIOResolveFieldContext<Account> context)
		{
			var filter = context.GetFilter<CardsFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAssignment>(
				"AccountAssignments",
				async ids =>
					await filter.Filtered(
							databaseContext.Cards.AsNoTracking(),
							cards => cards.SelectMany(card => card.Assignments)
								.Include(cardLabel => cardLabel.Card)
								.Where(cardLabel => ids.Contains(cardLabel.AccountId)))
						.ToListAsync(),
				cardLabel => cardLabel.AccountId);

			var cardLabels = await loader.LoadAsync(context.Source.Id);

			return cardLabels.Select(cardLabel => cardLabel.Card).ToList();
		}
	}
}