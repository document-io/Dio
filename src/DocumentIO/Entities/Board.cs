using System.Collections.Generic;

namespace DocumentIO
{
	public class Board
	{
		public int Id { get; set; }
		public string Name { get; set; }


		public int CompanyId { get; set; }
		public Company Company { get; set; }

		public ICollection<Column> Columns { get; set; }
	}
}