using System;

namespace DocumentIO
{
	public class CardAssignment
	{
		public Guid CardId { get; set; }
		public Card Card { get; set; }

		public Guid AccountId { get; set; }
		public Account Account { get; set; }
	}
}