using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CardColumnResolver : IDocumentIOResolver<Card, Column>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public CardColumnResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<Column> Resolve(DocumentIOResolveFieldContext<Card> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Column>(
				"CardColumn",
				async ids => await databaseContext.Cards
					.AsNoTracking()
					.Include(card => card.Column)
					.Where(card => ids.Contains(card.Id))
					.ToDictionaryAsync(card => card.Id, card => card.Column));

			return loader.LoadAsync(context.Source.Id);
		}
	}
}