using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteCardLabelResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCardLabelResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var input = context.GetArgument<CardLabel>();

			var cardLabel = await databaseContext
				.CardLabels
				.SingleAsync(x => x.CardId == input.CardId && x.LabelId == input.LabelId);

			databaseContext.CardLabels.Remove(cardLabel);

			await databaseContext.SaveChangesAsync();

			return await databaseContext.Cards.SingleAsync(x => x.Id == input.CardId);
		}
	}
}