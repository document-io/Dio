using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AttachmentsCountResolver : IDocumentIOResolver<object, int>
	{
		private readonly DatabaseContext databaseContext;

		public AttachmentsCountResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public Task<int> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<AttachmentsFilter>();

			return filter.Filtered(
					databaseContext.CardAttachments.AsNoTracking(),
					attachments => attachments.Where(attachment => attachment
						.Card
						.Column
						.Board
						.Organization
						.Accounts
						.Any(account => account.Id == accountId)),
					attachment => attachment.CreatedAt)
				.CountAsync();
		}
	}
}