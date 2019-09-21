using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class Organization
	{
		public Guid Id { get; set; }
		public string Name { get; set; }

		public IList<Invite> Invites { get; set; }
		public IList<Account> Accounts { get; set; }
		public IList<Board> Boards { get; set; }
	}
}