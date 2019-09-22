using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class BoardsFilter : DocumentIOFilter<Board>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<Board> queryable,
			Func<IQueryable<Board>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(board => board.Id == Id);

			if (Name != null)
				queryable = queryable.Where(board => board.Name.Contains(Name));

			return base.Filtered(queryable, query, orderBy);
		}
	}
}