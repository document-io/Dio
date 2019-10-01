namespace DocumentIO
{
	public abstract class DocumentIOFilterType<TEntity, TFilter> : DocumentIOInputGraphType<TFilter>
		where TFilter : DocumentIOFilter<TEntity>
	{
		protected DocumentIOFilterType()
		{
			NullField(x => x.Page);
			NullField(x => x.Size);
			NullField(x => x.OrderBy);
		}
	}
}