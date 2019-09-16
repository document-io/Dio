using System;

namespace DocumentIO
{
	public class ReadInviteModel
	{
		public int Id { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public Guid Identifier { get; set; }

		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime DueDate { get; set; }
	}
}