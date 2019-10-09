using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class EventsFilter : DocumentIOFilter<CardEvent>
	{
		public Guid? Id { get; set; }
		public string Content { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<CardEvent> queryable,
			Func<IQueryable<CardEvent>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(@event => @event.Id == Id);

			if (Content != null)
				queryable = queryable.Where(@event => @event.Content.Contains(Content));

			return base.Filtered(queryable, query, orderBy);
		}
	}
}