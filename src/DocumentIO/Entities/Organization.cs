using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DocumentIO
{
	public class Organization
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }

		public ICollection<Employee> Employees { get; set; }
		public ICollection<Invitation> Invitations { get; set; }
	}

	public class Invitation
	{
		public int Id { get; set; }
		public Guid UniqueKey { get; set; }

		public int CreatedId { get; set; }
		public Employee Created { get; set; }

		public int InvitedId { get; set; }
		public Employee Invited { get; set; }

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

		public int OrganizationId { get; set; }
		public Organization Organization { get; set; }

		public ICollection<Invitation> Invitations { get; set; }
	}

	public enum EmployeeRole
	{
		Manager,
		Worker
	}

	public class DocumentCategory
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public EmployeeRole RequiredRole { get; set; }
		public DateTime CreatedAt { get; set; }

		public int OrganizationId { get; set; }
		public Organization Organization { get; set; }
		
		public ICollection<Document> Documents { get; set; }
	}

	public class Document
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public DateTime CreatedAt { get; set; }
		public EmployeeRole RequiredRole { get; set; }
		public DateTime? ExpiredAt { get; set; }

		public int? AssignedId { get; set; }
		public Employee Assigned { get; set; }

		public int CategoryId { get; set; }
		public DocumentCategory Category { get; set; }

		public ICollection<DocumentVersion> Versions { get; set; }
	}

	public class DocumentVersion
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public int Version { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }

		public int EditorId { get; set; }
		public Employee Editor { get; set; }

		public ICollection<DocumentVersionReview> Reviews { get; set; }
	}

	public class DocumentVersionReview
	{
		public int Id { get; set; }
		public string Content { get; set; }

		public int ReviewerId { get; set; }
		public Employee Reviewer { get; set; }

		public int VersionId { get; set; }
		public DocumentVersion Version { get; set; }
	}
}
