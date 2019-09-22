using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteCommentResolver : IDocumentIOResolver<CardComment>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCommentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<CardComment> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var id = context.GetArgument<Guid>("id");

			var cardComment = await databaseContext
				.CardComments
				.SingleAsync(x => x.Id == id);

			databaseContext.CardComments.Remove(cardComment);

			await databaseContext.SaveChangesAsync();

			return cardComment;
		}
	}
}