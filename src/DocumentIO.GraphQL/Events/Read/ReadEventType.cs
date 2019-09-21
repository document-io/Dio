namespace DocumentIO
{
	public class ReadEventType : DocumentIOGraphType<CardEvent>
	{
		public ReadEventType()
		{
			Field(x => x.Id);
			Field(x => x.Content);

			DocumentIOField<ReadCardType, Card>("card")
				.Authorize(Roles.User)
				.ResolveAsync<EventCardResolver>();

			DocumentIOField<ReadAccountType, Account>("account")
				.Authorize(Roles.User)
				.ResolveAsync<EventAccountResolver>();
		}
	}
}