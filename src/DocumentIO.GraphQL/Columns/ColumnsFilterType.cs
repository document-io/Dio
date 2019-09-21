namespace DocumentIO
{
	public class ColumnsFilterType : DocumentIOFilterType<Column, ColumnsFilter>
	{
		public ColumnsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Name, nullable: true);
			Field(x => x.Order, nullable: true);
		}
	}
}