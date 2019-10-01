namespace DocumentIO
{
	public class ReadLabelType : DocumentIOGraphType<Label>
	{
		public ReadLabelType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Description);
			Field(x => x.Color);

			NonNullDocumentIOField<ReadBoardType, Board>("board")
				.AllowUser()
				.ResolveAsync<LabelBoardResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.AllowUser()
				.ResolveAsync<LabelCardsResolver>();
		}
	}
}