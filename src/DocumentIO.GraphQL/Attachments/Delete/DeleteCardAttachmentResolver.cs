using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteCardAttachmentResolver : IDocumentIOResolver<CardAttachment>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCardAttachmentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public async Task<CardAttachment> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<CardAttachment>();

			var attachment = await databaseContext.CardAttachments.FirstAsync(x => x.Id == model.Id);

			databaseContext.CardAttachments.Remove(attachment);

			await databaseContext.SaveChangesAsync();

			return attachment;
		}
	}
}