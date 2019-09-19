using GraphQL.Types;

namespace DocumentIO
{
	public class UpdateBoardGraphType : InputObjectGraphType<UpdateBoardModel>
	{
		public UpdateBoardGraphType()
		{
			Field(x => x.Name, nullable: true);
		}
	}
}