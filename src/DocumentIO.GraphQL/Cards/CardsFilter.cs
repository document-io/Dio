using System;
using System.Linq;

namespace DocumentIO
{
	public class CardsFilter : DocumentIOFilter<Card>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public int? Order { get; set; }

		public DateTime? DueDate { get; set; }
		
		public override IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<Card> queryable,
			Func<IQueryable<Card>, IQueryable<TPaginated>> query)
		{
			if (Id != null)
				queryable = queryable.Where(card => card.Id == Id);
			
			if (Name != null)
				queryable = queryable.Where(card => card.Name.Contains(Name));
			
			if (Order != null)
				queryable = queryable.Where(card => card.Order == Order);

			if (DueDate != null)
				queryable = queryable.Where(card => card.DueDate != null && card.DueDate < DueDate);

			return base.Filtered(queryable, query);
		}
	}
}