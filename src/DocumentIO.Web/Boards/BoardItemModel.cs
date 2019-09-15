namespace DocumentIO.Web
{
	public class BoardItemModel
	{
		public BoardItemModel(Board board)
		{
			Id = board.Id;
			Name = board.Name;
		}
		public int Id { get; set; }
		public string Name { get; set; }
	}
}
