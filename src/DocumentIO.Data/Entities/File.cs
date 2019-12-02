using System;

namespace DocumentIO
{
	public class File
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public string ContentDisposition { get; set; }
		public long? Length { get; set; }

		public Guid? AttachmentId { get; set; }
		public CardAttachment Attachment { get; set; }

		public byte[] Content { get; set; }
	}
}