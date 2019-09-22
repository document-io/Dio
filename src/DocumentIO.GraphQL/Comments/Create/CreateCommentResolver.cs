using System;
using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateCommentResolver : IDocumentIOResolver<CardComment>
	{
		private readonly DatabaseContext databaseContext;

		public CreateCommentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<CardComment> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var accountId = context.GetAccountId();
			var comment = context.GetArgument<CardComment>();

			comment.AccountId = accountId;
			comment.CreatedAt = DateTime.UtcNow;

			await databaseContext.CardComments.AddAsync(comment);
			await databaseContext.SaveChangesAsync();

			return comment;
		}
	}
}