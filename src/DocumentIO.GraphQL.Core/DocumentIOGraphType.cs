using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOGraphType<TSourceType> : ObjectGraphType<TSourceType>
	{
		public DocumentIOFieldBuilder<TSourceType, TProperty> NullField<TProperty>(
			Expression<Func<TSourceType, TProperty>> expression)
		{
			return new DocumentIOFieldBuilder<TSourceType, TProperty>(Field(expression, nullable: true));
		}

		protected DocumentIOFieldBuilder<TSourceType, TReturnType> DocumentIOField<TGraphType, TReturnType>(string name)
			where TGraphType : GraphType
		{
			return new DocumentIOFieldBuilder<TSourceType, TReturnType>(Field<NonNullGraphType<TGraphType>, TReturnType>(name));
		}

		protected DocumentIOFieldBuilder<TSourceType, IEnumerable<TReturnType>> DocumentIOListField<TGraphType, TReturnType>(string name)
			where TGraphType : GraphType
		{
			return new DocumentIOFieldBuilder<TSourceType, IEnumerable<TReturnType>>(
				Field<NonNullGraphType<ListGraphType<NonNullGraphType<TGraphType>>>, IEnumerable<TReturnType>>(name));
		}
	}
}