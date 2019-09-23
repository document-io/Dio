using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateLabelResolver : IDocumentIOResolver<Label>
	{
		private readonly DatabaseContext databaseContext;

		public UpdateLabelResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}

		public async Task<Label> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var model = context.GetArgument<Label>();

			var label = await databaseContext.Labels.SingleAsync(x => x.Id == model.Id);

			if (model.Name != null)
			{
				label.Name = model.Name;
			}

			if (model.Description != null)
			{
				label.Description = model.Description;
			}

			if (model.Color != null)
			{
				label.Color = model.Color;
			}

			await databaseContext.SaveChangesAsync();

			return label;
		}
	}
}