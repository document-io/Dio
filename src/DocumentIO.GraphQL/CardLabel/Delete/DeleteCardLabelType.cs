namespace DocumentIO
{
	public class DeleteCardLabelType : DocumentIOInputGraphType<CardLabel>
	{
		public DeleteCardLabelType()
		{
			Field(x => x.CardId);
			Field(x => x.LabelId);
		}
	}
}