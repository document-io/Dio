using System;
using System.Threading.Tasks;

namespace DocumentIO
{
	public class QueryAccountIdResolver : IDocumentIOResolver<Guid?>
	{
		private readonly DatabaseContext databaseContext;

		public QueryAccountIdResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public Task<Guid?> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();

			var result = accountId == Guid.Empty
				? (Guid?)null
				: accountId;

			return Task.FromResult(result);
		}
	}
}