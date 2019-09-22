namespace DocumentIO
{
	public class EventsFilterType : DocumentIOFilterType<CardEvent, EventsFilter>
	{
		public EventsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Content);
		}
	}
}