using System;
using System.Linq;

namespace DocumentIO
{
	public class EventsFilter : IFilter<CardEvent>
	{
		public Guid? Id { get; set; }
		public string Content { get; set; }

		public IQueryable<CardEvent> Filter(IQueryable<CardEvent> queryable)
		{
			if (Id != null)
				queryable = queryable.Where(@event => @event.Id == Id);

			if (Content != null)
				queryable = queryable.Where(@event => @event.Content.Contains(Content));

			return queryable;
		}
	}
}