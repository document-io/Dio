namespace DocumentIO
{
	public class CreateCardLabelType : DocumentIOInputGraphType<CardLabel>
	{
		public CreateCardLabelType()
		{
			Field(x => x.CardId);
			Field(x => x.LabelId);
		}
	}
}