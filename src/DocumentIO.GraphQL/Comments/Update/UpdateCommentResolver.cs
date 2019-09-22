using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateCommentResolver : IDocumentIOResolver<CardComment>
	{
		private readonly DatabaseContext databaseContext;

		public UpdateCommentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<CardComment> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<CardComment>();

			var cardComment = await databaseContext
				.CardComments
				.SingleAsync(x => x.Id == model.Id);

			cardComment.Text = model.Text;
			cardComment.UpdatedAt = DateTime.UtcNow;

			await databaseContext.SaveChangesAsync();

			return cardComment;
		}
	}
}