using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class LabelsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public LabelsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<LabelsFilter>();

			return filter.Filtered(
					databaseContext.Labels.AsNoTracking(),
					labels => labels.Where(label => label
						.Board
						.Organization
						.Accounts
						.Any(account => account.Id == accountId)),
					label => label.Id)
				.CountAsync();
		}
	}
}