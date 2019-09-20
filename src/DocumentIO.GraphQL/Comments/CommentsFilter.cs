using System;
using System.Linq;

namespace DocumentIO
{
	public class CommentsFilter : GraphQLFilter<CardComment>
	{
		public Guid? Id { get; set; }
		public string Content { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated>(
			IQueryable<CardComment> queryable,
			Func<IQueryable<CardComment>, IQueryable<TPaginated>> query)
		{
			if (Id != null)
				queryable = queryable.Where(comment => comment.Id == Id);
			
			if (Content != null)
				queryable = queryable.Where(comment => comment.Content.Contains(Content));

			return base.Filtered(queryable, query);
		}
	}
}