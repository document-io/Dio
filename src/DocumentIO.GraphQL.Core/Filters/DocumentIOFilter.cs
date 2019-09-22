using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public abstract class DocumentIOFilter<TEntity>
	{
		public int? Page { get; set; }
		public int? Size { get; set; }
		public DocumentIOOrderBy? OrderBy { get; set; }

		public virtual IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<TEntity> queryable,
			Func<IQueryable<TEntity>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			var filtered = query(queryable);

			if (Page != null && Size != null)
			{
				filtered = filtered.Skip(Size.Value * Page.Value - 1);
			}

			if (Size != null)
			{
				filtered = filtered.Take(Size.Value);
			}

			if (OrderBy != null)
			{
				filtered = OrderBy switch
				{
					DocumentIOOrderBy.Ascending => filtered.OrderBy(orderBy),
					DocumentIOOrderBy.Descending => filtered.OrderByDescending(orderBy),
					_ => filtered
				};
			}

			return filtered;
		}
	}
}