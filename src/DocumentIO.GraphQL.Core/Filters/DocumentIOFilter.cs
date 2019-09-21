using System;
using System.Linq;

namespace DocumentIO
{
	public abstract class DocumentIOFilter<TEntity>
	{
		public int? Page { get; set; }
		public int? Size { get; set; }

		public virtual IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<TEntity> queryable,
			Func<IQueryable<TEntity>, IQueryable<TPaginated>> query)
		{
			var paginated = query(queryable);

			if (Page != null && Size != null)
			{
				paginated = paginated.Skip(Size.Value * Page.Value - 1);
			}

			if (Size != null)
			{
				paginated = paginated.Take(Size.Value);
			}
			
			return paginated;
		}
	}
}