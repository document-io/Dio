using GraphQL.Types;

namespace DocumentIO
{
	public class CreateColumnGraphType : InputObjectGraphType<CreateColumnModel>
	{
		public CreateColumnGraphType()
		{
			Field(x => x.Name);
			Field(x => x.Order);
		}
	}
}