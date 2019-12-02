using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class AttachmentsFilter : DocumentIOFilter<CardAttachment>
	{
		public Guid? Id { get; set; }
		public string Name { get; set; }
		public string FileName { get; set; }
		public string ContentType { get; set; }
		public string ContentDisposition { get; set; }
		public long? Length { get; set; }
		public Guid? CardId { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<CardAttachment> queryable,
			Func<IQueryable<CardAttachment>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(attachment => attachment.Id == Id);

			if (Name != null)
				queryable = queryable.Where(attachment => attachment.Name == Name);

			if (FileName != null)
				queryable = queryable.Where(attachment => attachment.FileName == FileName);

			if (ContentType != null)
				queryable = queryable.Where(attachment => attachment.ContentType == ContentType);

			if (ContentDisposition != null)
				queryable = queryable.Where(attachment => attachment.ContentDisposition == ContentDisposition);

			if (Length != null)
				queryable = queryable.Where(attachment => attachment.Length == Length);

			if (CardId != null)
				queryable = queryable.Where(attachment => attachment.CardId == CardId);

			return base.Filtered(queryable, query, orderBy);
		}
	}
}