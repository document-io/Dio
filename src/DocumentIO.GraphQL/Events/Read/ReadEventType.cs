namespace DocumentIO
{
	public class ReadEventType : DocumentIOGraphType<CardEvent>
	{
		public ReadEventType()
		{
			Field(x => x.Id);
			Field(x => x.Content);

			NonNullDocumentIOField<ReadCardType, Card>("card")
				.Authorize(Roles.User)
				.ResolveAsync<EventCardResolver>();

			NonNullDocumentIOField<ReadAccountType, Account>("account")
				.Authorize(Roles.User)
				.ResolveAsync<EventAccountResolver>();
		}
	}
}