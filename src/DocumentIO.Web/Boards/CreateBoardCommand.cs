using Phema.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class CreateBoardCommand
	{
		public string Name { get; set; }

		public void Validate(DatabaseContext databaseContext, IValidationContext validationContext, Company company)
		{
			validationContext.When(this, c => c.Name)
				.IsNullOrWhitespace()
				.AddError("Имя доски не задано");
			validationContext.When(this, c => c.Name)
				.Is(() => databaseContext.Boards.Where(board => board.Company == company).Any(board => board.Name == Name))
				.AddError("Доска с таким именем ужде существует");
		}

		public async Task Create(DatabaseContext databaseContext, Company company)
		{
			var board = new Board
			{
				Company = company,
				Name = Name,
			};

			await databaseContext.Boards.AddAsync(board);
		}
	}
}
