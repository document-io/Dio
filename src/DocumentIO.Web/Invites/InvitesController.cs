using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;

namespace DocumentIO.Web
{
	[Route("invites")]
	[Authorize(Roles = Roles.Admin)]
	public class InvitesController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IValidationContext validationContext;

		public InvitesController(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			this.databaseContext = databaseContext;
			this.validationContext = validationContext;
		}

		[HttpGet] 
		public async Task<DocumentIOResponse<List<InviteItemModel>>> Invites()
		{
			var accountId = int.Parse(User.Identity.Name);

			var company = await databaseContext.Companies
				.SingleAsync(c => c.Invites.Any(invite => invite.Account.Id == accountId));

			return DocumentIOResponse.From(
				await databaseContext.Invites
					.Where(invite => invite.Company == company)
					.OrderByDescending(invite => invite.CreatedAt)
					.Select(invite => new InviteItemModel(invite))
					.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<DocumentIOResponse>> Create([FromBody] CreateInviteCommand command)
		{
			var accountId = int.Parse(User.Identity.Name);

			var company = await databaseContext.Companies
				.SingleAsync(c => c.Invites.Any(invite => invite.Account.Id == accountId));

			command.Validate(validationContext);

			if (!validationContext.IsValid())
			{
				return BadRequest(DocumentIOResponse.From(validationContext));
			}

			await command.Create(databaseContext, company);

			await databaseContext.SaveChangesAsync();
			
			return Ok();
		}

		[HttpDelete("{inviteId}")]
		public async Task<ActionResult<DocumentIOResponse>> Delete([FromRoute] DeleteInviteCommand command)
		{
			var accountId = int.Parse(User.Identity.Name);

			var company = await databaseContext.Companies
				.SingleAsync(c => c.Invites.Any(invite => invite.Account.Id == accountId));

			await command.Validate(databaseContext, validationContext, company);

			if (!validationContext.IsValid())
			{
				return BadRequest(DocumentIOResponse.From(validationContext));
			}

			await command.Delete(databaseContext);

			await databaseContext.SaveChangesAsync();

			return Ok();
		}
	}
}