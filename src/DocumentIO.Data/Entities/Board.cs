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

		public ICollection<Column> Columns { get; set; }
		public ICollection<Label> Labels { get; set; }
	}
}