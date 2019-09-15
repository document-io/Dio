using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Phema.Validation;

namespace DocumentIO.Web
{
	[Route("companies")]
	public class CompaniesController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;
		private readonly IValidationContext validationContext;

		public CompaniesController(DatabaseContext databaseContext, IValidationContext validationContext)
		{
			this.databaseContext = databaseContext;
			this.validationContext = validationContext;
		}

		[HttpPost]
		public async Task<ActionResult<DocumentIOResponse>> Create([FromBody] CreateCompanyCommand command)
		{
			command.Validate(databaseContext, validationContext);

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