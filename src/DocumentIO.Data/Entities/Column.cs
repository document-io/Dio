using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Column
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		public Guid BoardId { get; set; }
		public Board Board { get; set; }

		public ICollection<Card> Cards { get; set; }
	}
}