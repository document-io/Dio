using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ColumnsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public ColumnsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<ColumnsFilter>();

			return filter.Filtered(
					databaseContext.Columns.AsNoTracking(),
					columns => columns.Where(column => column
						.Board
						.Organization
						.Accounts
						.Any(account => account.Id == accountId)),
					column => column.CreatedAt)
				.CountAsync();
		}
	}
}