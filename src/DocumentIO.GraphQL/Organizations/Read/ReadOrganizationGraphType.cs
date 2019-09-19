using System.Collections.Generic;
using System.Linq;
using GraphQL.Authorization;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadOrganizationGraphType : ObjectGraphType<ReadOrganizationModel>
	{
		public ReadOrganizationGraphType(IDataLoaderContextAccessor accessor)
		{
			Name = "ReadOrganization";

			Field(x => x.Id);
			Field(x => x.Name);

			Field<ListGraphType<ReadBoardGraphType>, IEnumerable<ReadBoardModel>>("boards")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(context =>
				{
					var loader = accessor.Context.GetOrAddCollectionBatchLoader<int, ReadBoardModel>(
						"OrganizationBoards",
						async ids =>
						{
							return await context.GetDatabaseContext()
								.Boards
								.AsNoTracking()
								.Where(x => ids.Contains(x.OrganizationId))
								.Select(x => new ReadBoardModel
								{
									Id = x.Id,
									OrganizationId = x.OrganizationId,
									Name = x.Name
								})
								.ToListAsync();
						},
						x => x.OrganizationId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}