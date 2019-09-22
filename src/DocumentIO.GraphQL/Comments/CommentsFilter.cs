using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class CommentsFilter : DocumentIOFilter<CardComment>
	{
		public Guid? Id { get; set; }
		public string Content { get; set; }
		public DateTimeOffset? CreatedAt { get; set; }
		public DateTimeOffset? UpdatedAt { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<CardComment> queryable,
			Func<IQueryable<CardComment>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(comment => comment.Id == Id);
			
			if (Content != null)
				queryable = queryable.Where(comment => comment.Text.Contains(Content));

			if (CreatedAt != null)
				queryable = queryable.Where(comment => comment.CreatedAt >= CreatedAt);

			if (UpdatedAt != null)
				queryable = queryable.Where(comment => comment.CreatedAt >= UpdatedAt);

			return base.Filtered(queryable, query, orderBy);
		}
	}
}