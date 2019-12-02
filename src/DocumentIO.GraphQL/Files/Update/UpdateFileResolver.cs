using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateFileResolver : IDocumentIOResolver<File>
	{
		private readonly DatabaseContext databaseContext;

		public UpdateFileResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public async Task<File> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<File>();

			var file = await databaseContext.Files.FirstAsync(x => x.Id == model.Id);

			if (model.Name != null)
			{
				file.Name = model.Name;
			}

			await databaseContext.SaveChangesAsync();

			return file;
		}
	}
}