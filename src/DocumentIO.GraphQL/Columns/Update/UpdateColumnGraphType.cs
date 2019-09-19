using GraphQL.Types;

namespace DocumentIO
{
	public class UpdateColumnGraphType : InputObjectGraphType<UpdateColumnModel>
	{
		public UpdateColumnGraphType()
		{
			Field(x => x.Name, nullable: true);
			Field(x => x.Order, nullable: true);
		}
	}
}