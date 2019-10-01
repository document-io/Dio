using System.Threading.Tasks;

namespace DocumentIO
{
	public class CountResolver : IDocumentIOResolver<object>
	{
		public Task<object> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			return Task.FromResult(new object());
		}
	}
}