using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class CardsFilter : DocumentIOFilter<Card>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public int? Order { get; set; }

		public DateTimeOffset? DueDate { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<Card> queryable,
			Func<IQueryable<Card>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(card => card.Id == Id);

			if (Name != null)
				queryable = queryable.Where(card => card.Name.Contains(Name));

			if (Order != null)
				queryable = queryable.Where(card => card.Order == Order);

			if (DueDate != null)
				queryable = queryable.Where(card => card.DueDate != null && card.DueDate < DueDate);

			return base.Filtered(queryable, query, orderBy);
		}
	}
}