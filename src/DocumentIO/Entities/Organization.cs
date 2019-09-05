using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Organization
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }

		public ICollection<Employee> Employees { get; set; }
		public ICollection<Invite> Invites { get; set; }
	}

	public class Invite
	{
		public int Id { get; set; }
		public Guid UniqueKey { get; set; }
		public EmployeeRole Role { get; set; }

		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }

		public int OrganizationId { get; set; }
		public Organization Organization { get; set; }
	}

	public class Employee
	{
		public int Id { get; set; }
		public EmployeeRole Role { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public DateTime CreatedAt { get; set; }

		public int OrganozationId { get; set; }
		public Organization Organization { get; set; }

		public ICollection<Invite> Invites { get; set; }
	}

	public enum EmployeeRole
	{
		// TODO: 
		Administrator,
		User
	}

	public class DocumentCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public EmployeeRole RequiredRole { get; set; }

		public ICollection<Document> Documents { get; set; }
	}

	public class Document
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime? ExpiredAt { get; set; }
		public EmployeeRole RequiredRole { get; set; }

		public int? ResponsibleId { get; set; }
		public Employee Responsible { get; set; }

		public int CategoryId { get; set; }
		public DocumentCategory Category { get; set; }

		public ICollection<DocumentVersion> Versions { get; set; }
	}

	public class DocumentVersion
	{
		public int Id { get; set; }
		public string Content { get; set; }
		public DateTime EditedAt { get; set; }

		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }

		public ICollection<DocumentVersionComment> Comments { get; set; }
	}

	public class DocumentVersionComment
	{
		public int Id { get; set; }
		public string Content { get; set; }

		public int EmployeeId { get; set; }
		public Employee Employee { get; set; }

		public int VersionId { get; set; }
		public DocumentVersion Version { get; set; }
	}
}