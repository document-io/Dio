using GraphQL.Types;

namespace DocumentIO
{
	public class BoardsFilterType : InputObjectGraphType<BoardsFilter>
	{
		public BoardsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Name, nullable: true);
		}
	}
}