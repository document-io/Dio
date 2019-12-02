using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class FilesFilter : DocumentIOFilter<File>
	{
		public Guid? Id { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<File> queryable,
			Func<IQueryable<File>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(file => file.Id == Id);

			// TODO: Фильтрация
			
			return base.Filtered(queryable, query, orderBy);
		}
	}
}