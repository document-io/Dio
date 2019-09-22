namespace DocumentIO
{
	public abstract class DocumentIOFilterType<TEntity, TFilter> : DocumentIOInputGraphType<TFilter>
		where TFilter : DocumentIOFilter<TEntity>
	{
		protected DocumentIOFilterType()
		{
			NullField(x => x.Page);
			NullField(x => x.Size)
				.DefaultValue(20);
			NullField(x => x.OrderBy);
		}
	}
}