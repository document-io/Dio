using GraphQL.Types;

namespace DocumentIO
{
	public class ColumnsFilterType : InputObjectGraphType<ColumnsFilter>
	{
		public ColumnsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Name, nullable: true);
			Field(x => x.Order, nullable: true);
		}
	}
}