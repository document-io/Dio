using System;
using System.Linq.Expressions;
using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOInputGraphType<TSourceType> : InputObjectGraphType<TSourceType>
	{
		public DocumentIOFieldBuilder<TSourceType, TProperty> NullField<TProperty>(
			Expression<Func<TSourceType, TProperty>> expression)
		{
			return new DocumentIOFieldBuilder<TSourceType, TProperty>(Field(expression, nullable: true));
		}

		public DocumentIOFieldBuilder<TSourceType, TReturnType> NonNullField<TGraphType, TReturnType>(string name)
			where TGraphType : GraphType
		{
			return new DocumentIOFieldBuilder<TSourceType, TReturnType>(
				Field<NonNullGraphType<TGraphType>, TReturnType>(name));
		}
	}
}