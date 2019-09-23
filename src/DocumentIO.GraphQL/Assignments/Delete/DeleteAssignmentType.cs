namespace DocumentIO
{
	public class DeleteAssignmentType : DocumentIOInputGraphType<CardAssignment>
	{
		public DeleteAssignmentType()
		{
			Field(x => x.CardId);
			Field(x => x.AccountId);
		}
	}
}