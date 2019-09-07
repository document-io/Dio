using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO.Web
{
	[Authorize]
	[Route("employees")]
	public class EmployeesController : ControllerBase
	{
		private readonly DatabaseContext databaseContext;

		public EmployeesController(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		// TODO: Что должно быть в модели?
		[HttpGet]
		public async Task<DocumentIOResponse<List<EmployeeListItemModel>>> Employees()
		{
			// TODO: Pagination?
			var employees = await databaseContext.Employees
				.AsNoTracking()
				.Include(e => e.Assignments)
				.Select(e => new EmployeeListItemModel(e))
				.ToListAsync();

			return DocumentIOResponse.From(employees);
		}

		// TODO: Что должно быть в модели?
		[HttpGet("self")]
		public async Task<DocumentIOResponse<EmployeeModel>> Self()
		{
			var id = int.Parse(User.Identity.Name);

			var employee = await databaseContext.Employees
				.AsNoTracking()
				.Where(e => e.Id == id)
				.Select(e => new EmployeeModel(e))
				.SingleAsync();

			return DocumentIOResponse.From(employee);
		}

		// TODO: Зачем он нужен? Что должно быть в модели?
		[HttpGet("{id}")]
		public async Task<DocumentIOResponse<EmployeeModel>> ById(int id)
		{
			var employee = await databaseContext.Employees
				.AsNoTracking()
				.Where(e => e.Id == id)
				.Select(e => new EmployeeModel(e))
				.SingleAsync();

			return DocumentIOResponse.From(employee);
		}
	}
}