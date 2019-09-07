using System;

namespace DocumentIO
{
	public class DocumentAssignment
	{
		public int Id { get; set; }
		public DateTime? DueDate { get; set; }

		public int DocumentId { get; set; }
		public Document Document { get; set; }

		public int PerformerId { get; set; }
		public Employee Performer { get; set; }
	}
}