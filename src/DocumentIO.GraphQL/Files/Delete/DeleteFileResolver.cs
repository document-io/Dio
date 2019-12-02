using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteFileResolver : IDocumentIOResolver<File>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteFileResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public async Task<File> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<File>();

			var file = await databaseContext.Files.FirstAsync(x => x.Id == model.Id);

			databaseContext.Files.Remove(file);

			await databaseContext.SaveChangesAsync();

			return file;
		}
	}
}