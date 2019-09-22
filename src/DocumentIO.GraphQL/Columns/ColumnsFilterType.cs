namespace DocumentIO
{
	public class ColumnsFilterType : DocumentIOFilterType<Column, ColumnsFilter>
	{
		public ColumnsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Name);
			NullField(x => x.Order);
		}
	}
}