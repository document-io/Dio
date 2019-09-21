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
				.Authorize(Roles.User)
				.ResolveAsync<ColumnBoardResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.Authorize(Roles.User)
				.Filtered<CardsFilterType>()
				.ResolveAsync<ColumnCardsResolver>();
		}
	}
}