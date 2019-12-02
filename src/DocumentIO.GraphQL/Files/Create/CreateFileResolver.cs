using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateFileResolver : IDocumentIOResolver<File>
	{
		private readonly DatabaseContext databaseContext;

		public CreateFileResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<File> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var file = context.GetArgument<File>();

			await databaseContext.Files.AddAsync(file);
			await databaseContext.SaveChangesAsync();

			return file;
		}
	}
}