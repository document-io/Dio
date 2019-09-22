using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class AttachmentFilter : DocumentIOFilter<CardAttachment>
	{
		public Guid? Id { get; set; }
		public string MimeType { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<CardAttachment> queryable,
			Func<IQueryable<CardAttachment>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(attachment => attachment.Id == Id);

			if (MimeType != null)
				queryable = queryable.Where(attachment => attachment.MimeType == MimeType);

			return base.Filtered(queryable, query, orderBy);
		}
	}
}