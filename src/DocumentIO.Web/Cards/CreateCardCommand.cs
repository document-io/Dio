using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Phema.Validation;
using Phema.Validation.Conditions;

namespace DocumentIO.Web
{
	public class CreateCardCommand
	{
		public string Name { get; set; }
		public int Position { get; set; }
		public DateTime? DueDate { get; set; }

		public string Markdown { get; set; }

		public int ColumnId { get; set; }

		public void Validate(IValidationContext validationContext)
		{
			validationContext.When(this, c => c.Name)
				.IsNullOrWhitespace()
				.AddError("Название колонки не задано");

			validationContext.When(this, c => c.Position)
				.IsEqual(0)
				.AddError("Не задана позиция карточки");

			validationContext.When(this, c => c.ColumnId)
				.IsEqual(0)
				.AddError("Не указана карточка");
		}

		public async Task Create(DatabaseContext databaseContext)
		{
			var column = await databaseContext.Columns.SingleAsync(c => c.Id == ColumnId);

			var card = new Card
			{
				Column = column,
				Markdown = Markdown,
				Name = Name,
				Position = Position,
				DueDate = DueDate
			};

			await databaseContext.Cards.AddAsync(card);
		}
	}
}