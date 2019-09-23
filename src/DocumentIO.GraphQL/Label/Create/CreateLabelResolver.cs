using System.Threading.Tasks;

namespace DocumentIO
{
	public class CreateLabelResolver : IDocumentIOResolver<Label>
	{
		private readonly DatabaseContext databaseContext;

		public CreateLabelResolver(DatabaseContext databaseContext)
		{
			this.databaseContext = databaseContext;
		}
	
		public async Task<Label> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			var label = context.GetArgument<Label>();

			await databaseContext.Labels.AddAsync(label);
			await databaseContext.SaveChangesAsync();

			return label;
		}
	}
}