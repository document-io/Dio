using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateCardAttachmentResolver : IDocumentIOResolver<CardAttachment>
	{
		private readonly DatabaseContext databaseContext;

		public UpdateCardAttachmentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public async Task<CardAttachment> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<CardAttachment>();

			var file = await databaseContext.CardAttachments.FirstAsync(x => x.Id == model.Id);

			if (model.Name != null)
			{
				file.Name = model.Name;
			}

			await databaseContext.SaveChangesAsync();

			return file;
		}
	}
}