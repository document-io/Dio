using System;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO
{
	public class DocumentIOSchema : Schema
	{
		public DocumentIOSchema(IServiceProvider serviceProvider) : base(serviceProvider)
		{
			Query = serviceProvider.GetRequiredService<DocumentIOQuery>();
			Mutation = serviceProvider.GetRequiredService<DocumentIOMutation>();
		}
	}
}