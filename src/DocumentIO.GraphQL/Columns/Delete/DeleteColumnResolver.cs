using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteColumnResolver : IDocumentIOResolver<Column>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteColumnResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public async Task<Column> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<Column>();

			var column = await databaseContext.Columns.SingleAsync(x => x.Id == model.Id);

			databaseContext.Columns.Remove(column);

			await databaseContext.SaveChangesAsync();

			return column;
		}
	}
}