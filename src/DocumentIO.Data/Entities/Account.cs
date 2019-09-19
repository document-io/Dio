using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Account
	{
		public Guid Id { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public DateTime CreatedAt { get; set; }

		public Invite Invite { get; set; }

		public Guid OrganizationId { get; set; }
		public Organization Organization { get; set; }

		public ICollection<CardComment> Comments { get; set; }
		public ICollection<CardAssignment> Assignments { get; set; }
		public ICollection<CardAttachment> Attachments { get; set; }
		public ICollection<CardEvent> Events { get; set; }
	}
}