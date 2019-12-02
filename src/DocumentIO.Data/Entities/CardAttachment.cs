using System;
using System.Collections.Generic;

namespace DocumentIO
{
	public class CardAttachment
	{
		public Guid Id { get; set; }
		public DateTimeOffset CreatedAt { get; set; }

		public string Name { get; set; }
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public string ContentDisposition { get; set; }
		public long? Length { get; set; }
		public byte[] Content { get; set; }

		public Guid CardId { get; set; }
		public Card Card { get; set; }

		public Guid AccountId { get; set; }
		public Account Account { get; set; }
	}
}