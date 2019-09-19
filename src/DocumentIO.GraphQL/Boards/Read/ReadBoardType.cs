using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadBoardType : ObjectGraphType<Board>
	{
		public ReadBoardType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.CreatedAt);

			Field<ListGraphType<ReadColumnType>, IEnumerable<Column>>("columns")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Column>(
						"BoardColumns",
						async ids => await databaseContext.Columns
							.Where(column => ids.Contains(column.BoardId))
							.ToListAsync(),
						column => column.BoardId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ReadOrganizationType, Organization>("organization")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Organization>(
						"BoardOrganization",
						async ids => await databaseContext.Boards
							.Include(board => board.Organization)
							.Where(board => ids.Contains(board.Id))
							.ToDictionaryAsync(board => board.Id, board => board.Organization));

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadLabelType>, IEnumerable<Label>>("labels")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Label>(
						"BoardLabels",
						async ids => await databaseContext.Labels
							.Where(label => ids.Contains(label.BoardId))
							.ToListAsync(),
						label => label.BoardId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}