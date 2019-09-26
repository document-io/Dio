using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateBoardResolver : IDocumentIOResolver<Board>
	{
		private readonly DatabaseContext databaseContext;

		public CreateBoardResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Board> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var board = context.GetArgument<Board>();

			var organization = await databaseContext.Organizations.GetByAccountId(accountId);

			board.CreatedAt = DateTime.UtcNow;
			board.Organization = organization;

			board.Columns = new List<Column>
			{
				new Column
				{
					Name = "Шаблоны",
					Order = 0,
					CreatedAt = DateTime.UtcNow,
					Cards = new List<Card>
					{
						new Card
						{
							Name = "Приветствие",
							Order = 0,
							Content = "Вы создали первую карточку"
						}
					}
				}
			};

			board.Labels = new List<Label>
			{
				new Label
				{
					Name = "Важное",
					Description = "Требует срочного решения",
					Color = "#e0221f"
				},
				new Label
				{
					Name = "Ожидает",
					Description = "Ждет решения",
					Color = "#f4c20c"
				}
			};

			await databaseContext.Boards.AddAsync(board);
			await databaseContext.SaveChangesAsync();

			return board;
		}
	}
}