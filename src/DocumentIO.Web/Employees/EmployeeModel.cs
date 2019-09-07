namespace DocumentIO.Web
{
	public class EmployeeModel
	{
		public EmployeeModel(Employee employee)
		{
			Email = employee.Email;
			FirstName = employee.FirstName;
			MiddleName = employee.MiddleName;
			LastName = employee.LastName;
		}

		public string Email { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }
	}
}