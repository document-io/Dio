using System;
using System.Linq;

namespace DocumentIO
{
	public class AttachmentFilter : Filter<CardAttachment>
	{
		public Guid? Id { get; set; }
		public string MimeType { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<CardAttachment> queryable,
			Func<IQueryable<CardAttachment>, IQueryable<TPaginated>> query)
		{
			if (Id != null)
				queryable = queryable.Where(attachment => attachment.Id == Id);

			if (MimeType != null)
				queryable = queryable.Where(attachment => attachment.MimeType == MimeType);

			return base.Filtered(queryable, query);
		}
	}
}