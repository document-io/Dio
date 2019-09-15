using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phema.Validation;

namespace DocumentIO.Web
{
	[Authorize]
	[Route("columns")]
	public class ColumnsController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IValidationContext validationContext;

		public ColumnsController(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			this.databaseContext = databaseContext;
			this.validationContext = validationContext;
		}

		[HttpPost]
		public async Task<ActionResult<DocumentIOResponse>> Create([FromBody] CreateColumnCommand command)
		{
			command.Validate(validationContext);

			if (!validationContext.IsValid())
			{
				return BadRequest(DocumentIOResponse.From(validationContext));
			}

			await command.Create(databaseContext);

			await databaseContext.SaveChangesAsync();

			return Ok();
		}

		// TODO: Move column position
		// TODO: Delete column
	}
}