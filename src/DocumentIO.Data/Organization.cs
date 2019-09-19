using System.Collections.Generic;

namespace DocumentIO
{
	public class Organization
	{
		public int Id { get; set; }
		public string Name { get; set; }

		public ICollection<Invite> Invites { get; set; }
		public ICollection<Account> Accounts { get; set; }
		public ICollection<Board> Boards { get; set; }
	}
}