namespace DocumentIO
{
	public class ReadColumnType : DocumentIOGraphType<Column>
	{
		public ReadColumnType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Order);

			DocumentIOField<ReadBoardType, Board>("board")
				.ResolveAsync<ColumnBoardResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.Filtered<CardsFilterType>()
				.ResolveAsync<ColumnCardsResolver>();
		}
	}
}