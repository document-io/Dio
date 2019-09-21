namespace DocumentIO
{
	public class CreateColumnType : DocumentIOInputGraphType<Column>
	{
		public CreateColumnType()
		{
			Field(x => x.Name);
			Field(x => x.BoardId);
		}
	}
}