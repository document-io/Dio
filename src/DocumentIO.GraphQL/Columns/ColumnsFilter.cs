using System;
using System.Linq;

namespace DocumentIO
{
	public class ColumnsFilter : IFilter<Column>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public int? Order { get; set; }

		public IQueryable<Column> Filter(IQueryable<Column> queryable)
		{
			if (Id != null)
				queryable = queryable.Where(column => column.Id == Id);

			if (Name != null)
				queryable = queryable.Where(column => column.Name.Contains(Name));

			if (Order != null)
				queryable = queryable.Where(column => column.Order == Order);

			return queryable;
		}
	}
}