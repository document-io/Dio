namespace DocumentIO
{
	public class ReadEventType : DocumentIOGraphType<CardEvent>
	{
		public ReadEventType()
		{
			Field(x => x.Id);
			Field(x => x.Content);

			NonNullDocumentIOField<ReadCardType, Card>("card")
				.AllowUser()
				.ResolveAsync<EventCardResolver>();

			NonNullDocumentIOField<ReadAccountType, Account>("account")
				.AllowUser()
				.ResolveAsync<EventAccountResolver>();
		}
	}
}