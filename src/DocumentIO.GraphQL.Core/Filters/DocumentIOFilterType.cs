using GraphQL.Types;

namespace DocumentIO
{
	public abstract class DocumentIOFilterType<TEntity, TFilter> : InputObjectGraphType<TFilter>
		where TFilter : DocumentIOFilter<TEntity>
	{
		protected DocumentIOFilterType()
		{
			Field(x => x.Page, nullable: true);
			Field(x => x.Size, nullable: true)
				.DefaultValue(20);
			Field(x => x.OrderBy, nullable: true);
		}
	}
}