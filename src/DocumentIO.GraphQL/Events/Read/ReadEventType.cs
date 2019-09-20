namespace DocumentIO
{
	public class ReadEventType : DocumentIOGraphType<CardEvent>
	{
		public ReadEventType()
		{
			Field(x => x.Id);
			Field(x => x.Content);

			DocumentIOField<ReadCardType, Card>("card")
				.ResolveAsync<EventCardResolver>();

			DocumentIOField<ReadAccountType, Account>("account")
				.ResolveAsync<EventAccountResolver>();
		}
	}
}