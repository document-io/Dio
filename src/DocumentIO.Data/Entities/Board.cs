using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Board
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }

		public Guid OrganizationId { get; set; }
		public Organization Organization { get; set; }

		public IList<Column> Columns { get; set; }
		public IList<Label> Labels { get; set; }
	}
}