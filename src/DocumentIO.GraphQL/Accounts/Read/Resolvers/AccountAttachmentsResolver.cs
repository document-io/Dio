using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AccountAttachmentsResolver : IDocumentIOResolver<Account, IEnumerable<CardAttachment>>
	{
		private readonly IDataLoaderContextAccessor accessor;
		private readonly DatabaseContext databaseContext;

		public AccountAttachmentsResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<IEnumerable<CardAttachment>> Resolve(DocumentIOResolveFieldContext<Account> context)
		{
			var filter = context.GetFilter<AttachmentFilter>();

			var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAttachment>(
				"AccountAttachments",
				async ids => await filter.Filtered(
						databaseContext.CardAttachments.AsNoTracking(),
						attachments => attachments.Where(cardLabel => ids.Contains(cardLabel.AccountId)))
					.ToListAsync(),
				cardLabel => cardLabel.AccountId);

			return loader.LoadAsync(context.Source.Id);
		}
	}
}