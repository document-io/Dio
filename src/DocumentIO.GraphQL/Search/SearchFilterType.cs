namespace DocumentIO
{
	public class SearchFilterType : DocumentIOFilterType<Search, SearchFilter>
	{
		public SearchFilterType()
		{
			NullField(x => x.Name);
			NullField(x => x.CreatedAt);
		}
	}
}