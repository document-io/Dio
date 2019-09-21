using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class QueryOrganizationResolver : IDocumentIOResolver<object, Organization>
	{
		private readonly DatabaseContext databaseContext;

		public QueryOrganizationResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public async Task<Organization> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();

			return await databaseContext.Organizations
				.AsNoTracking()
				.GetByAccountId(accountId);
		}
	}
}