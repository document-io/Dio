using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Employee
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string PasswordHash { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public DateTime CreatedAt { get; set; }

		public ICollection<Document> Documents { get; set; }
		public ICollection<DocumentVersion> Versions { get; set; }
		public ICollection<DocumentVersionReview> Reviews { get; set; }
		public ICollection<DocumentAssignment> Assignments { get; set; }
	}
}