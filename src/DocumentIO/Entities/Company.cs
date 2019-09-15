using System.Collections.Generic;

namespace DocumentIO
{
	public class Company
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Invite> Invites { get; set; }
	}
}