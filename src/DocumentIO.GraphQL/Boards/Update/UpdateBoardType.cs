namespace DocumentIO
{
	public class UpdateBoardType : DocumentIOInputGraphType<Board>
	{
		public UpdateBoardType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
		}
	}
}