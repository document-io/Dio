using System;
using System.Linq;

namespace DocumentIO
{
	public class InviteFilter : IFilter<Invite>
	{
		public Guid? Id { get; set; }
		public string Role { get; set; }
		public string Description { get; set; }

		public IQueryable<Invite> Filter(IQueryable<Invite> queryable)
		{
			if (Id != null)
				queryable = queryable.Where(invite => invite.Id == Id);

			if (Role != null)
				queryable = queryable.Where(invite => invite.Role == Role);

			if (Description != null)
				queryable = queryable.Where(invite => invite.Description.Contains(Description));

			return queryable;
		}
	}
}