using System;

namespace DocumentIO
{
	public class Card
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }

		public DateTime? DueDate { get; set; }

		public string Markdown { get; set; }

		public int ColumnId { get; set; }
		public Column Column { get; set; }
	}
}