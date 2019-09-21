using System;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class AttachmentAccountResolver : IDocumentIOResolver<CardAttachment, Account>
	{
		private readonly DatabaseContext databaseContext;
		private readonly IDataLoaderContextAccessor accessor;

		public AttachmentAccountResolver(IDataLoaderContextAccessor accessor, DatabaseContext databaseContext)
		{
			this.accessor = accessor;
			this.databaseContext = databaseContext;
		}
		
		public Task<Account> Resolve(DocumentIOResolveFieldContext<CardAttachment> context)
		{
			var loader = accessor.Context.GetOrAddBatchLoader<Guid, Account>(
				"AttachmentAccount",
				async ids => await databaseContext.CardAttachments.AsNoTracking()
					.Include(assignment => assignment.Account)
					.Where(assignment => ids.Contains(assignment.AccountId))
					.ToDictionaryAsync(x => x.AccountId, x => x.Account));

			return loader.LoadAsync(context.Source.AccountId);
		}
	}
}