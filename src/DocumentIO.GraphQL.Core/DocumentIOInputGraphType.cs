using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOInputGraphType<TSourceType> : InputObjectGraphType<TSourceType>
	{
		protected DocumentIOFieldBuilder<TSourceType, TReturnType> NonNullField<TGraphType, TReturnType>(string name)
			where TGraphType : GraphType
		{
			return new DocumentIOFieldBuilder<TSourceType, TReturnType>(Field<NonNullGraphType<TGraphType>, TReturnType>(name));
		}
	}
}