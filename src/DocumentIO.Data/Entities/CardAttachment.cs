using System;

namespace DocumentIO
{
	public class CardAttachment
	{
		public Guid Id { get; set; }
		public string MimeType { get; set; }
		public byte[] Content { get; set; }

		public Guid CardId { get; set; }
		public Card Card { get; set; }

		public Guid AccountId { get; set; }
		public Account Account { get; set; }
	}
}