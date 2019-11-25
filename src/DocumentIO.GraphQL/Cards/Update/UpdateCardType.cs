namespace DocumentIO
{
	public class UpdateCardType : DocumentIOInputGraphType<Card>
	{
		public UpdateCardType()
		{
			Field(x => x.Id);
			NullField(x => x.ColumnId);
			NullField(x => x.Name);
			NullField(x => x.Order);
			NullField(x => x.DueDate);
			NullField(x => x.Content);
		}
	}
}