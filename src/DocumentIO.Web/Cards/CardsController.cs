using System.Collections;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Phema.Validation;

namespace DocumentIO.Web
{
	[Authorize]
	[Route("cards")]
	public class CardsController : ControllerBase
	{
		private readonly IValidationContext validationContext;
		private readonly DatabaseContext databaseContext;

		public CardsController(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			this.databaseContext = databaseContext;
			this.validationContext = validationContext;
		}

		[HttpPost]
		public async Task<ActionResult<DocumentIOResponse>> Create([FromBody] CreateCardCommand command)
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
	}
}