using System.Collections.Generic;

namespace DocumentIO
{
	public class DocumentCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		public ICollection<Document> Documents { get; set; }
	}
}