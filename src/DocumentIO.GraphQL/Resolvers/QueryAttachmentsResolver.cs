using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryAttachmentsResolver : IGraphQLResolver<object, IEnumerable<CardAttachment>>
	{		
		private readonly DatabaseContext databaseContext;

		public QueryAttachmentsResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<IEnumerable<CardAttachment>> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var filter = context.GetFilter<AttachmentFilter>();

			var organization = await databaseContext.Organizations
				.AsNoTracking()
				.GetByAccountId(accountId);

			return await filter.Filtered(
					databaseContext.CardAttachments.AsNoTracking(),
					attachments => attachments.Where(attachment =>
						attachment.Account.Organization == organization))
				.ToListAsync();
		}
	}
}