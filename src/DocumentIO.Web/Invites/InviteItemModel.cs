using System;

namespace DocumentIO.Web
{
	public class InviteItemModel
	{
		public InviteItemModel(Invite invite)
		{
			Id = invite.Id;
			Role = invite.Role;
			Email = invite.Email;
			Identifier = invite.Identifier;
			Description = invite.Description;
			CreatedAt = invite.CreatedAt;
			DueDate = invite.DueDate;
			AccountId = invite.Account?.Id;
		}

		public int Id { get; }
		public string Role { get; }
		public string Email { get; }
		public Guid Identifier { get; }

		public string Description { get;}
		public DateTime CreatedAt { get; }
		public DateTime? DueDate { get; }

		public int? AccountId { get; }
	}
}