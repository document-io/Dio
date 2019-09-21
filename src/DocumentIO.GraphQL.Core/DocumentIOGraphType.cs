using System.Collections.Generic;
using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOGraphType<TSourceType> : ObjectGraphType<TSourceType>
	{
		protected DocumentIOFieldBuilder<TSourceType, TReturnType> DocumentIOField<TGraphType, TReturnType>(string name)
			where TGraphType : ComplexGraphType<TReturnType>
		{
			return new DocumentIOFieldBuilder<TSourceType, TReturnType>(Field<TGraphType, TReturnType>(name));
		}

		protected DocumentIOFieldBuilder<TSourceType, IEnumerable<TReturnType>> DocumentIOListField<TGraphType, TReturnType>(string name)
			where TGraphType : ComplexGraphType<TReturnType>
		{
			return new DocumentIOFieldBuilder<TSourceType, IEnumerable<TReturnType>>(
				Field<ListGraphType<TGraphType>, IEnumerable<TReturnType>>(name));
		}
	}
}