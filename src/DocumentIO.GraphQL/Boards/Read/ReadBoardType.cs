using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadBoardType : DocumentIOGraphType<Board>
	{
		public ReadBoardType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.CreatedAt);

			FilteredField<ListGraphType<ReadColumnType>, IEnumerable<Column>, ColumnsFilterType>("columns")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Board, ColumnsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Column>(
						"BoardColumns",
						async ids =>
							await filter.Filtered(
									databaseContext.Columns.AsNoTracking(),
									columns => columns.Where(column => ids.Contains(column.BoardId)))
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
							.AsNoTracking()
							.Include(board => board.Organization)
							.Where(board => ids.Contains(board.Id))
							.ToDictionaryAsync(board => board.Id, board => board.Organization));

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadLabelType>, IEnumerable<Label>, LabelsFilterType>("labels")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Board, LabelsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, Label>(
						"BoardLabels",
						async ids =>
							await filter.Filtered(
									databaseContext.Labels.AsNoTracking(),
									labels => labels.Where(label => ids.Contains(label.BoardId)))
								.ToListAsync(),
						label => label.BoardId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}