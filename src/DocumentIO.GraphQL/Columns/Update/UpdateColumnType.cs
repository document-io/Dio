namespace DocumentIO
{
	public class UpdateColumnType : DocumentIOInputGraphType<Column>
	{
		public UpdateColumnType()
		{
			Field(x => x.Id);
			Field(x => x.Name, nullable: true);
			Field(x => x.Order, nullable: true);
		}
	}
}