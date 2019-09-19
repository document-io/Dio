using GraphQL.Types;

namespace DocumentIO
{
	public class CreateBoardGraphType : InputObjectGraphType<CreateBoardModel>
	{
		public CreateBoardGraphType()
		{
			Name = "CreateBoard";

			Field(x => x.Name);
		}
	}
}