namespace DocumentIO
{
	public class EventsFilterType : FilterType<CardEvent, EventsFilter>
	{
		public EventsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Content, nullable: true);
		}
	}
}