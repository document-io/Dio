using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO
{
	public class CreateBoardModelValidation : IGraphQLValidation<CreateBoardModel>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IHttpContextAccessor httpContextAccessor;

		public CreateBoardModelValidation(DatabaseContext databaseContext, IHttpContextAccessor httpContextAccessor)
		{
			this.databaseContext = databaseContext;
			this.httpContextAccessor = httpContextAccessor;
		}
		
		public async Task Validate(IValidationContext validationContext, CreateBoardModel model)
		{
			validationContext.When(model, m => m.Name)
				.IsNullOrWhitespace()
				.AddError("Имя доски не задано");

			if (validationContext.IsValid(model, m => m.Name))
			{
				var accountId = int.Parse(httpContextAccessor.HttpContext.User.Identity.Name);

				var account = await databaseContext.Accounts
					.Include(x => x.Organization)
					.SingleAsync(x => x.Id == accountId);

				var boardExists = await databaseContext.Boards
					.Where(x => x.Organization == account.Organization)
					.AnyAsync(x => x.Name == model.Name);

				validationContext.When(model, m => m.Name)
					.Is(() => boardExists)
					.AddError("Доска с таким именем уже существует");
			}
		}
	}
}