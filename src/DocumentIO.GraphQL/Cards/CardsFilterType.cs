using GraphQL.Types;

namespace DocumentIO
{
	public class CardsFilterType : InputObjectGraphType<CardsFilter>
	{
		public CardsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Name, nullable: true);
			Field(x => x.Order, nullable: true);
			Field(x => x.DueDate, nullable: true);
		}
	}
}