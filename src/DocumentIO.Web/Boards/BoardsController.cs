using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Phema.Validation;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DocumentIO.Web
{
	[Authorize]
	[Route("boards")]
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
		public async Task<DocumentIOResponse<IEnumerable<BoardItemModel>>> Boards()
		{
			var accountId = int.Parse(User.Identity.Name);

			var company = await databaseContext.Companies
				.SingleAsync(c => c.Invites.Any(invite => invite.Account.Id == accountId));

			return DocumentIOResponse.From<IEnumerable<BoardItemModel>>(
				await databaseContext.Boards
					.Where(board => board.Company == company)
					.Select(board => new BoardItemModel(board))
					.ToListAsync());
		}

		[HttpPost]
		public async Task<ActionResult<DocumentIOResponse>> Create([FromBody] CreateBoardCommand command)
		{
			var accountId = int.Parse(User.Identity.Name);

			var company = await databaseContext.Companies
				.SingleAsync(c => c.Invites.Any(invite => invite.Account.Id == accountId));

			command.Validate(databaseContext, validationContext, company);

			if (!validationContext.IsValid())
			{
				return BadRequest(DocumentIOResponse.From(validationContext));
			}

			await command.Create(databaseContext, company);

			await databaseContext.SaveChangesAsync();

			return Ok();
		}
	}
}