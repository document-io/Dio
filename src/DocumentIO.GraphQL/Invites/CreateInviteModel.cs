using System;
using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateInviteModel
	{
		public string Role { get; set;  }
		public string Email { get; set; }
		public string Description { get; set; }
		public DateTime DueDate { get; set; }

		public async Task<Invite> Create(DatabaseContext databaseContext, Account account, Organization organization)
		{
			var invite = new Invite
			{
				Account = account,
				Organization = organization,
				Description = Description,
				Email = Email,
				Role = Role,
				DueDate = DueDate,
				Identifier = Guid.NewGuid(),
				CreatedAt = DateTime.UtcNow
			};

			await databaseContext.Invites.AddAsync(invite);

			return invite;
		}
	}
}