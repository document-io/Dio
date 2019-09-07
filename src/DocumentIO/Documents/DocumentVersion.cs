using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class DocumentVersion
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }

		public int DocumentId { get; set; }
		public Document Document { get; set; }

		public int EditedById { get; set; }
		public Employee EditedBy { get; set; }

		public DocumentVersionContent Content { get; set; }

		public ICollection<DocumentVersionReview> Reviews { get; set; }
	}
}