using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Card
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		public DateTime? DueDate { get; set; }

		public string Markdown { get; set; }

		public Guid ColumnId { get; set; }
		public Column Column { get; set; }

		public ICollection<CardLabel> Labels { get; set; }
	}
}