using System;

namespace DocumentIO
{
	public class CardComment
	{
		public Guid Id { get; set; }
		public string Content { get; set; }
		public DateTime CreatedAt { get; set; }

		public Guid CardId { get; set; }
		public Card Card { get; set; }

		public Guid AccountId { get; set; }
		public Account Account { get; set; }
	}
}