using System;
using System.Linq;

namespace DocumentIO
{
	public class LabelsFilter : IFilter<Label>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Color { get; set; }

		public IQueryable<Label> Filter(IQueryable<Label> queryable)
		{
			if (Id != null)
				queryable = queryable.Where(label => label.Id == Id);

			if (Name != null)
				queryable = queryable.Where(label => label.Name.Contains(Name));

			if (Description != null)
				queryable = queryable.Where(label => label.Description.Contains(Description));

			if (Color != null)
				queryable = queryable.Where(label => label.Color == Color);

			return queryable;
		}
	}
}