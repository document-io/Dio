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

			DocumentIOField<ReadBoardType, Board>("board")
				.Authorize(Roles.User)
				.ResolveAsync<LabelBoardResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.Authorize(Roles.User)
				.ResolveAsync<LabelCardsResolver>();
		}
	}
}