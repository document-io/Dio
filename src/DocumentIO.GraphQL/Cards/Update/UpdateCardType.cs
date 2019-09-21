namespace DocumentIO
{
	public class UpdateCardType : DocumentIOInputGraphType<Card>
	{
		public UpdateCardType()
		{
			Field(x => x.Id);
			Field(x => x.Name, nullable: true);
			Field(x => x.Order, nullable: true);
			Field(x => x.DueDate, nullable: true);
			Field(x => x.Content, nullable: true);
		}
	}
}