namespace DocumentIO
{
	public class CreateCardType : DocumentIOInputGraphType<Card>
	{
		public CreateCardType()
		{
			Field(x => x.Name);
			Field(x => x.Description);
			Field(x => x.ColumnId);
		}
	}
}