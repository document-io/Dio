using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Card
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public int Order { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }
		public DateTime? DueDate { get; set; }

		public string Content { get; set; }

		public Guid ColumnId { get; set; }
		public Column Column { get; set; }

		public IList<CardLabel> Labels { get; set; }
		public IList<CardComment> Comments { get; set; }
		public IList<CardAssignment> Assignments { get; set; }
		public IList<CardAttachment> Attachments { get; set; }
		public IList<CardEvent> Events { get; set; }
	}
}