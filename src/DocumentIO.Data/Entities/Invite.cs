using System;

namespace DocumentIO
{
	public class Invite
	{
		public Guid Id { get; set; }
		public Guid Secret { get; set; }
		public string Role { get; set; }
		public string Description { get; set; }
		public DateTimeOffset? DueDate { get; set; }
		public DateTimeOffset CreatedAt { get; set; }

		public Guid? AccountId { get; set; }
		public Account Account { get; set; }

		public Guid OrganizationId { get; set; }
		public Organization Organization { get; set; }
	}
}