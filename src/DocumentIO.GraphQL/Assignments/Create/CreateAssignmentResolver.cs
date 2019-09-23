using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class CreateAssignmentResolver : IDocumentIOResolver<Card>
	{
		private readonly DatabaseContext databaseContext;

		public CreateAssignmentResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Card> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var assigmnemt = context.GetArgument<CardAssignment>();

			assigmnemt.CreatedAt = DateTime.UtcNow;

			await databaseContext.CardAssignments.AddAsync(assigmnemt);

			await databaseContext.SaveChangesAsync();

			return await databaseContext.Cards.SingleAsync(x => x.Id == assigmnemt.CardId);
		}
	}
}