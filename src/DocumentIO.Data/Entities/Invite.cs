using System;

namespace DocumentIO
{
	public class Invite
	{
		public Guid Id { get; set; }
		public Guid Secret { get; set; }
		public string Role { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? DueDate { get; set; }

		public Guid? AccountId { get; set; }
		public Account Account { get; set; }

		public Guid OrganizationId { get; set; }
		public Organization Organization { get; set; }
	}
}