using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteAssignmentResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteAssignmentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<CardAssignment>();

			var assignment = await databaseContext.CardAssignments
				.SingleAsync(x => x.AccountId == model.AccountId && x.CardId == model.CardId);

			databaseContext.CardAssignments.Remove(assignment);

			await databaseContext.SaveChangesAsync();

			return await databaseContext.Cards.SingleAsync(x => x.Id == model.CardId);
		}
	}
}