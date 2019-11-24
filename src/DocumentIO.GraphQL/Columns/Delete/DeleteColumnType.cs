namespace DocumentIO
{
	public class DeleteColumnType : DocumentIOInputGraphType<Column>
	{
		public DeleteColumnType()
		{
			Field(x => x.Id);
		}
	}
}