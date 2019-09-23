namespace DocumentIO
{
	public class CreateAssignmentType : DocumentIOInputGraphType<CardAssignment>
	{
		public CreateAssignmentType()
		{
			Field(x => x.CardId);
			Field(x => x.AccountId);
		}
	}
}