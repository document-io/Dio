using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class InviteFilter : DocumentIOFilter<Invite>
	{
		public Guid? Id { get; set; }
		public string Role { get; set; }
		public string Description { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<Invite> queryable,
			Func<IQueryable<Invite>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(invite => invite.Id == Id);

			if (Role != null)
				queryable = queryable.Where(invite => invite.Role == Role);

			if (Description != null)
				queryable = queryable.Where(invite => invite.Description.Contains(Description));

			return base.Filtered(queryable, query, orderBy);
		}
	}
}