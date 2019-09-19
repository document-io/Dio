using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateBoardModel
	{
		public string Name { get; set; }

		public async Task<Board> Create(DatabaseContext databaseContext, int accountId)
		{
			var account = await databaseContext.Accounts
				.Include(x => x.Organization)
				.SingleAsync(x => x.Id == accountId);

			var board = new Board
			{
				Name = Name,
				Organization = account.Organization,
				CreatedAt = DateTime.UtcNow
			};

			await databaseContext.Boards.AddAsync(board);

			return board;
		}
	}
}