using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace DocumentIO
{
	public class QueryVersionResolver : IDocumentIOResolver<string>
	{
		private readonly IConfiguration configuration;

		public QueryVersionResolver(IConfiguration configuration)
		{
			this.configuration = configuration;
		}

		public Task<string> Resolve(DocumentIOResolveFieldContext<object> context)
		{
			return Task.FromResult(configuration.GetValue<string>("Version"));
		}
	}
}