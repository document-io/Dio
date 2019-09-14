using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public static class Roles
	{
		public const string User = "user";
		public const string Admin = "admin";

		public static string[] All { get; } = { User, Admin };
	}
	
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Invite> Invites { get; set; }
	}

	public class Invite
	{
		public int Id { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public Guid Identifier { get; set; }

		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? DueDate { get; set; }

		public int CompanyId { get; set; }
		public Company Company { get; set; }

		public Account Account { get; set; }
	}

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
	public class Board
	{
		public int Id { get; set; }
		public string Name { get; set; }


		public int CompanyId { get; set; }
		public Company Company { get; set; }
	}
}