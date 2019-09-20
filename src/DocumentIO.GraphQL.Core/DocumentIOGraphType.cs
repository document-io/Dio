using GraphQL.Builders;
using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOGraphType<TSourceType> : ObjectGraphType<TSourceType>
	{
		protected DocumentIOFieldBuilder<TSourceType, TReturnType> DocumentIOField<TGraphType, TReturnType>(string name)
		{
			return new DocumentIOFieldBuilder<TSourceType, TReturnType>(Field<TGraphType, TReturnType>(name));
		}
	}
}