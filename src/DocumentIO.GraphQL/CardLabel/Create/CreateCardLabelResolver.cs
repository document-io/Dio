using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateCardLabelResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public CreateCardLabelResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var cardLabel = context.GetArgument<CardLabel>();

			await databaseContext.CardLabels.AddAsync(cardLabel);

			await databaseContext.SaveChangesAsync();

			return await databaseContext.Cards.SingleAsync(x => x.Id == cardLabel.CardId);
		}
	}
}