namespace DocumentIO
{
	public class BoardsFilterType : FilterType<Board, BoardsFilter>
	{
		public BoardsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Name, nullable: true);
		}
	}
}