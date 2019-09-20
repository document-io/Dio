using GraphQL.Types;

namespace DocumentIO
{
	public class EventsFilterType : InputObjectGraphType<EventsFilter>
	{
		public EventsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Content, nullable: true);
		}
	}
}