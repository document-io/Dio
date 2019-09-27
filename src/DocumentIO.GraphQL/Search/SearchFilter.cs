using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class SearchFilter : DocumentIOFilter<Search>
	{
		public string Name { get; set; }
		public DateTime? CreatedAt { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(IQueryable<Search> queryable, Func<IQueryable<Search>, IQueryable<TPaginated>> query, Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Name != null)
				queryable = queryable.Where(x => x.Name.Contains(Name));

			if (CreatedAt != null)
				queryable = queryable.Where(x => x.CreatedAt > CreatedAt);

			return base.Filtered(queryable, query, orderBy);
		}
	}
}