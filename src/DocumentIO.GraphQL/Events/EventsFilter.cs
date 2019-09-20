using System;
using System.Linq;

namespace DocumentIO
{
	public class EventsFilter : GraphQLFilter<CardEvent>
	{
		public Guid? Id { get; set; }
		public string Content { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<CardEvent> queryable, 
			Func<IQueryable<CardEvent>, IQueryable<TPaginated>> query)
		{
			if (Id != null)
				queryable = queryable.Where(@event => @event.Id == Id);

			if (Content != null)
				queryable = queryable.Where(@event => @event.Content.Contains(Content));

			return base.Filtered(queryable, query);
		}
	}
}