using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateCardAttachmentResolver : IDocumentIOResolver<CardAttachment>
	{
		private readonly DatabaseContext databaseContext;

		public CreateCardAttachmentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<CardAttachment> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var attachment = context.GetArgument<CardAttachment>();

			attachment.AccountId = context.GetAccountId();
			await databaseContext.CardAttachments.AddAsync(attachment);
			await databaseContext.SaveChangesAsync();

			return attachment;
		}
	}
}