using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Phema.Validation;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DocumentIO.Web
{
	[Route("boards")]
	[Authorize]
	public class BoardsController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IValidationContext validationContext;

		public BoardsController(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			this.databaseContext = databaseContext;
			this.validationContext = validationContext;
		}

		[HttpGet]
		public async Task<IEnumerable<BoardItemModel>> Boards()
		{
			var accountId = int.Parse(User.Identity.Name);

			var company = await databaseContext.Companies
				.SingleAsync(c => c.Invites.Any(invite => invite.Account.Id == accountId));

			return await databaseContext.Boards
				.Where(board => board.Company == company)
				.Select(board => new BoardItemModel(board))
				.ToListAsync();
		}

		[HttpPost]
		public async Task<ActionResult> Create([FromBody] CreateBoardCommand command)
		{

			var accountId = int.Parse(User.Identity.Name);

			var company = await databaseContext.Companies
				.SingleAsync(c => c.Invites.Any(invite => invite.Account.Id == accountId));

			command.Validate(databaseContext, validationContext, company);

			if (!validationContext.IsValid())
			{
				return BadRequest(validationContext.Into());
			}

			await command.Create(databaseContext, company);

			await databaseContext.SaveChangesAsync();

			return Ok();
		}
	}
}
