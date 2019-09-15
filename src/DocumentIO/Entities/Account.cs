using System;

namespace DocumentIO
{
	public class Account
	{
		public int Id { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime CreatedAt { get; set; }

		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }


		public int InviteId { get; set; }
		public Invite Invite { get; set; }
	}
}