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
				.AllowUser()
				.ResolveAsync<ColumnBoardResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.AllowUser()
				.Filtered<CardsFilterType>()
				.ResolveAsync<ColumnCardsResolver>();
		}
	}
}