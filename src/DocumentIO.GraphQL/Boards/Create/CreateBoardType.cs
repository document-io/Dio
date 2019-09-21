namespace DocumentIO
{
	public class CreateBoardType : DocumentIOInputGraphType<Board>
	{
		public CreateBoardType()
		{
			Field(x => x.Name);
		}
	}
}