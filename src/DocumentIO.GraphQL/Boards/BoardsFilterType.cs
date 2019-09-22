namespace DocumentIO
{
	public class BoardsFilterType : DocumentIOFilterType<Board, BoardsFilter>
	{
		public BoardsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Name);
		}
	}
}