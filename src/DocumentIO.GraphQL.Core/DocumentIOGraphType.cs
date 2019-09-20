using GraphQL.Builders;
using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOGraphType<TSourceType> : ObjectGraphType<TSourceType>
	{
		protected FieldBuilder<TSourceType, TReturnType> FilteredField<TGraphType, TReturnType, TFilterType>(string name)
			where TGraphType : IGraphType
			where TFilterType : IComplexGraphType, new()
		{
			var filter = new TFilterType();

			return Field<TGraphType, TReturnType>(name)
				.Configure(q =>
				{
					foreach (var field in filter.Fields)
					{
						q.Arguments.Add(new QueryArgument(field.Type)
						{
							Description = field.Description,
							Name = field.Name,
							DefaultValue = field.DefaultValue,
							Metadata = field.Metadata,
							ResolvedType = field.ResolvedType
						});
					}
				});
		}
	}
}