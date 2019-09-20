using GraphQL.Types;

namespace DocumentIO
{
	public abstract class FilterType<TEntity, TFilter> : InputObjectGraphType<TFilter>
		where TFilter : Filter<TEntity>
	{
		protected FilterType()
		{
			Field(x => x.Page, nullable: true);
			Field(x => x.Size, nullable: true)
				.DefaultValue(20);
		}
	}
}