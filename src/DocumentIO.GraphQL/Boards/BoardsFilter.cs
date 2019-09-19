using System;
using System.Linq;

namespace DocumentIO
{
	public class BoardsFilter : IFilter<Board>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }

		public IQueryable<Board> Filter(IQueryable<Board> queryable)
		{
			if (Id != null)
				queryable = queryable.Where(board => board.Id == Id);

			if (Name != null)
				queryable = queryable.Where(board => board.Name.Contains(Name));

			return queryable;
		}
	}
}