using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class ColumnsFilter : DocumentIOFilter<Column>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public int? Order { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<Column> queryable,
			Func<IQueryable<Column>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(column => column.Id == Id);

			if (Name != null)
				queryable = queryable.Where(column => column.Name.Contains(Name));

			if (Order != null)
				queryable = queryable.Where(column => column.Order == Order);

			return base.Filtered(queryable, query, orderBy);
		}
	}
}