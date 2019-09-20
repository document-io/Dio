namespace DocumentIO
{
	public class CardsFilterType : FilterType<Card, CardsFilter>
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