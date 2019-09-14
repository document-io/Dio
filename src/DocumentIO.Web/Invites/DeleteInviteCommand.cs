using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;

namespace DocumentIO.Web
{
	public class DeleteInviteCommand
	{
		public int InviteId { get; set; }

		public async Task Validate(DatabaseContext databaseContext, IValidationContext validationContext, Company company)
		{
			var invite = await databaseContext.Invites
				.Include(i => i.Account)
				.FirstOrDefaultAsync(i => i.Id == InviteId);

			validationContext.When(this, i => i.InviteId)
				.Is(() => invite == null)
				.AddError("Приглашение не найдено");

			if (validationContext.IsValid(this, i => i.InviteId))
			{
				validationContext.When(this, i => i.InviteId)
					.Is(() => invite.CompanyId != company.Id)
					.AddError("Удалять можно инвайты только своей компании");
			}

			if (validationContext.IsValid(this, i => i.InviteId))
			{
				validationContext.When(this, i => i.InviteId)
					.Is(() => invite.Account != null)
					.AddError("Нельзя удалить приглашение, так как по нему был создан аккаунт");
			}
		}

		public async Task Delete(DatabaseContext databaseContext)
		{
			var invite = await databaseContext.Invites.SingleAsync(x => x.Id == InviteId);

			databaseContext.Invites.Remove(invite);
		}
	}
}