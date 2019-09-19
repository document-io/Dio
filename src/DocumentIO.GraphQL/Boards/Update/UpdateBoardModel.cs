using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateBoardModel
	{
		public string Name { get; set; }

		public async Task<Board> Update(DatabaseContext databaseContext, int accountId, int boardId)
		{
			var board = await databaseContext.Boards
				.Where(x => x.Organization.Accounts.Any(u => u.Id == accountId))
				.SingleAsync(x => x.Id == boardId);

			if (Name != null)
			{
				board.Name = Name;
			}

			return board;
		}
	}
}