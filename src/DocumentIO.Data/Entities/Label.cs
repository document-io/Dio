using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Label
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public string Color { get; set; }

		public Guid BoardId { get; set; }
		public Board Board { get; set; }

		public IList<CardLabel> Cards { get; set; }
	}
}