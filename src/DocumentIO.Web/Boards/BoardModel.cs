using System.Collections.Generic;
using System.Linq;

namespace DocumentIO.Web
{
	public class BoardModel
	{
		public BoardModel(Board board)
		{
			Id = board.Id;
			Name = board.Name;

			Columns = board.Columns.Select(columns => new ColumnModel(columns)).ToList();
		}

		public int Id { get; }
		public string Name { get; }

		public ICollection<ColumnModel> Columns { get; }
	}
}