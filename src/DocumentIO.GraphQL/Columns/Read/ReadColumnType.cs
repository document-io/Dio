namespace DocumentIO
{
	public class ReadColumnType : DocumentIOGraphType<Column>
	{
		public ReadColumnType()
		{
			Interface<SearchInterface>();

			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.CreatedAt);
			Field(x => x.Order);

			NonNullDocumentIOField<ReadBoardType, Board>("board")
				.Authorize(Roles.User)
				.ResolveAsync<ColumnBoardResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.Authorize(Roles.User)
				.Filtered<CardsFilterType>()
				.ResolveAsync<ColumnCardsResolver>();
		}
	}
}