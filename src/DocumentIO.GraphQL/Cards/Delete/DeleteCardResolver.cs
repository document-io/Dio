using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class DeleteCardResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public DeleteCardResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
		
		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<Card>();

			var card = await databaseContext.Cards
				.Include(x => x.Assignments)
				.Include(x => x.Attachments)
				.Include(x => x.Comments)
				.Include(x => x.Events)
				.Include(x => x.Labels)
				.SingleAsync(x => x.Id == model.Id);

			foreach (var assignment in card.Assignments)
			{
				databaseContext.CardAssignments.Remove(assignment);
			}

			foreach (var attachment in card.Attachments)
			{
				databaseContext.CardAttachments.Remove(attachment);
			}

			foreach (var comment in card.Comments)
			{
				databaseContext.CardComments.Remove(comment);
			}

			foreach (var @event in card.Events)
			{
				databaseContext.CardEvents.Remove(@event);
			}

			foreach (var label in card.Labels)
			{
				databaseContext.CardLabels.Remove(label);
			}

			databaseContext.Cards.Remove(card);

			await databaseContext.SaveChangesAsync();

			return card;
		}
	}
}