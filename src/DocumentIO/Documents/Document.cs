using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Document
	{
		public int Id { get; set; }
		public Guid Registration { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }

		public int CategoryId { get; set; }
		public DocumentCategory Category { get; set; }

		public int CreatorId { get; set; }
		public Employee Creator { get; set; }

		public ICollection<DocumentAssignment> Assignments { get; set; }
		public ICollection<DocumentVersion> Versions { get; set; }
	}
}