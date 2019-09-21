using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOInputGraphType<TSourceType> : InputObjectGraphType<TSourceType>
	{
		protected DocumentIOFieldBuilder<TSourceType, TReturnType> DocumentIOField<TGraphType, TReturnType>(string name)
		{
			return new DocumentIOFieldBuilder<TSourceType, TReturnType>(Field<TGraphType, TReturnType>(name));
		}
	}
}