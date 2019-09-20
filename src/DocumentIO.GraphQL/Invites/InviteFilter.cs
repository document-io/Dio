using System;
using System.Linq;

namespace DocumentIO
{
	public class InviteFilter : GraphQLFilter<Invite>
	{
		public Guid? Id { get; set; }
		public string Role { get; set; }
		public string Description { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated>
			(IQueryable<Invite> queryable,
			Func<IQueryable<Invite>, IQueryable<TPaginated>> query)
		{
			if (Id != null)
				queryable = queryable.Where(invite => invite.Id == Id);

			if (Role != null)
				queryable = queryable.Where(invite => invite.Role == Role);

			if (Description != null)
				queryable = queryable.Where(invite => invite.Description.Contains(Description));

			return base.Filtered(queryable, query);
		}
	}
}