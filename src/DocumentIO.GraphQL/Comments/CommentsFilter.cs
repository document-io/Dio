using System;
using System.Linq;

namespace DocumentIO
{
	public class CommentsFilter : DocumentIOFilter<CardComment>
	{
		public Guid? Id { get; set; }
		public string Content { get; set; }
		public DateTime? CreatedAt { get; set; }
		public DateTime? UpdatedAt { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<CardComment> queryable,
			Func<IQueryable<CardComment>, IQueryable<TPaginated>> query)
		{
			if (Id != null)
				queryable = queryable.Where(comment => comment.Id == Id);
			
			if (Content != null)
				queryable = queryable.Where(comment => comment.Content.Contains(Content));

			if (CreatedAt != null)
				queryable = queryable.Where(comment => comment.CreatedAt >= CreatedAt);

			if (UpdatedAt != null)
				queryable = queryable.Where(comment => comment.CreatedAt >= UpdatedAt);

			return base.Filtered(queryable, query);
		}
	}
}