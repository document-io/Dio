using System;

namespace DocumentIO.Web
{
	public class EmployeeListItemModel
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
		public DateTime CreatedAt { get; set; }
		public int AssignmentsCount { get; set; }

		public EmployeeListItemModel(Employee employee)
		{
			Id = employee.Id;
			Email = employee.Email;
			FirstName = employee.FirstName;
			MiddleName = employee.MiddleName;
			LastName = employee.LastName;
			CreatedAt = employee.CreatedAt;
			AssignmentsCount = employee.Assignments.Count;
		}
	}
}