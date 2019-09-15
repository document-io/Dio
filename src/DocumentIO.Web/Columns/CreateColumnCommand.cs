using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class CreateColumnCommand
	{
		// TODO: Валидация того, что доска принадлежит нужной организации
		public int BoardId { get; set; }
		public string Name { get; set; }
		public int Position { get; set; }

		public void Validate(IValidationContext validationContext)
		{
			validationContext.When(this, c => c.BoardId)
				.IsEqual(0)
				.AddError("Доска не указана");

			validationContext.When(this, c => c.Name)
				.IsNullOrWhitespace()
				.AddError("Укажите название колонки");

			validationContext.When(this, c => c.Position)
				.IsEqual(0)
				.AddError("Не указана позиция колонки");
		}

		public async Task Create(DatabaseContext databaseContext)
		{
			var board = await databaseContext.Boards.SingleAsync(b => b.Id == BoardId);

			var column = new Column
			{
				Board = board,
				Name = Name,
				Position = Position
			};

			await databaseContext.Columns.AddAsync(column);
		}
	}
}