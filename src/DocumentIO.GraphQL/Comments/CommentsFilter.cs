using System;
using System.Linq;

namespace DocumentIO
{
	public class CommentsFilter : IFilter<CardComment>
	{
		public Guid? Id { get; set; }
		public string Content { get; set; }

		public IQueryable<CardComment> Filter(IQueryable<CardComment> queryable)
		{
			if (Id != null)
				queryable = queryable.Where(comment => comment.Id == Id);
			
			if (Content != null)
				queryable = queryable.Where(comment => comment.Content.Contains(Content));

			return queryable;
		}
	}
}