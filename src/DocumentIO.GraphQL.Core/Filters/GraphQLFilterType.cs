using GraphQL.Types;

namespace DocumentIO
{
	public abstract class GraphQLFilterType<TEntity, TFilter> : InputObjectGraphType<TFilter>
		where TFilter : GraphQLFilter<TEntity>
	{
		protected GraphQLFilterType()
		{
			Field(x => x.Page, nullable: true);
			Field(x => x.Size, nullable: true)
				.DefaultValue(20);
		}
	}
}