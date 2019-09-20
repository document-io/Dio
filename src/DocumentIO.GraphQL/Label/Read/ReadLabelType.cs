using System.Collections.Generic;
using GraphQL.Types;

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
				.ResolveAsync<LabelBoardResolver>();

			DocumentIOField<ListGraphType<ReadCardType>, IEnumerable<Card>>("cards")
				.ResolveAsync<LabelCardsResolver>();
		}
	}
}