using System;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadCardType : ObjectGraphType<Card>
	{
		public ReadCardType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Order);
			Field(x => x.DueDate, nullable: true);
			Field(x => x.Markdown);

			Field<ReadColumnType, Column>("column")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Column>(
						"CardColumn",
						async ids => await databaseContext.Cards
							.Include(card => card.Column)
							.Where(card => ids.Contains(card.Id))
							.ToDictionaryAsync(card => card.Id, card => card.Column));

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}