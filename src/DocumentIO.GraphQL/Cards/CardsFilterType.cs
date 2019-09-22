namespace DocumentIO
{
	public class CardsFilterType : DocumentIOFilterType<Card, CardsFilter>
	{
		public CardsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Name);
			NullField(x => x.Order);
			NullField(x => x.DueDate);
		}
	}
}