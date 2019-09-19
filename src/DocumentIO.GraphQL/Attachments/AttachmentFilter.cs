using System;
using System.Linq;

namespace DocumentIO
{
	public class AttachmentFilter : IFilter<CardAttachment>
	{
		public Guid? Id { get; set; }
		public string MimeType { get; set; }

		public IQueryable<CardAttachment> Filter(IQueryable<CardAttachment> queryable)
		{
			if (Id != null)
				queryable = queryable.Where(attachment => attachment.Id == Id);

			if (MimeType != null)
				queryable = queryable.Where(attachment => attachment.MimeType == MimeType);

			return queryable;
		}
	}
}