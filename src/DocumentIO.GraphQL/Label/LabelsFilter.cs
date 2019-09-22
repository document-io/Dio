using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class LabelsFilter : DocumentIOFilter<Label>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Color { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<Label> queryable,
			Func<IQueryable<Label>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(label => label.Id == Id);

			if (Name != null)
				queryable = queryable.Where(label => label.Name.Contains(Name));

			if (Description != null)
				queryable = queryable.Where(label => label.Description.Contains(Description));

			if (Color != null)
				queryable = queryable.Where(label => label.Color == Color);

			return base.Filtered(queryable, query, orderBy);
		}
	}
}