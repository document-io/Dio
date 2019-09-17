using System;

namespace DocumentIO
{
	public class Invite
	{
		public int Id { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public Guid Identifier { get; set; }

		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? DueDate { get; set; }

		public int? AccountId { get; set; }
		public Account Account { get; set; }
		
		public int OrganizationId { get; set; }
		public Organization Organization { get; set; }
	}
}