using System;
using System.Linq;

namespace DocumentIO
{
	public abstract class Filter<TEntity>
	{
		public int? Page { get; set; }
		public int Size { get; set; }

		public virtual IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<TEntity> queryable,
			Func<IQueryable<TEntity>, IQueryable<TPaginated>> query)
		{
			var paginated = query(queryable);

			if (Page != null)
				paginated = paginated.Skip(Size * Page.Value - 1).Take(Size);

			return paginated;
		}
	}
}