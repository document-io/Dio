using System.Collections.Generic;

namespace DocumentIO
{
	public class Column
	{
		public int Id { get; set; }

		public string Name { get; set; }
		public int Position { get; set; }
		

		public int BoardId { get; set; }
		public Board Board { get; set; }

		public ICollection<Card> Cards { get; set; }
	}
}