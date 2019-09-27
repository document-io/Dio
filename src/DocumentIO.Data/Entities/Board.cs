using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Board : Search
	{
		public Guid Id { get; set; }
		public Guid OrganizationId { get; set; }
		public Organization Organization { get; set; }

		public IList<Column> Columns { get; set; }
		public IList<Label> Labels { get; set; }
	}
}