using System;
using System.Linq;

namespace DocumentIO
{
	public class BoardsFilter : GraphQLFilter<Board>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<Board> queryable,
			Func<IQueryable<Board>, IQueryable<TPaginated>> query)
		{
			if (Id != null)
				queryable = queryable.Where(board => board.Id == Id);

			if (Name != null)
				queryable = queryable.Where(board => board.Name.Contains(Name));

			return base.Filtered(queryable, query);
		}
	}
}