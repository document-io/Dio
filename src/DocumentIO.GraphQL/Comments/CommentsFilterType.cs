using GraphQL.Types;

namespace DocumentIO
{
	public class CommentsFilterType : InputObjectGraphType<CommentsFilter>
	{
		public CommentsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Content, nullable: true);
		}
	}
}