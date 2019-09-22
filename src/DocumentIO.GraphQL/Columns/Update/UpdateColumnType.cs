namespace DocumentIO
{
	public class UpdateColumnType : DocumentIOInputGraphType<Column>
	{
		public UpdateColumnType()
		{
			Field(x => x.Id);
			NullField(x => x.Name);
			NullField(x => x.Order);
		}
	}
}