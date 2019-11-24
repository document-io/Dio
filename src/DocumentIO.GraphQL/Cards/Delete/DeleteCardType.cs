namespace DocumentIO
{
	public class DeleteCardType : DocumentIOInputGraphType<Card>
	{
		public DeleteCardType()
		{
			Field(x => x.Id);
		}
	}
}