using System.Collections.Generic;
using GraphQL.Types;

namespace DocumentIO
{
	public class ReadBoardType : DocumentIOGraphType<Board>
	{
		public ReadBoardType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.CreatedAt);

			DocumentIOField<ListGraphType<ReadColumnType>, IEnumerable<Column>>("columns")
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<BoardColumnsResolver>();

			DocumentIOField<ReadOrganizationType, Organization>("organization")
				.ResolveAsync<BoardOrganizationResolver>();

			DocumentIOField<ListGraphType<ReadLabelType>, IEnumerable<Label>>("labels")
				.Filtered<LabelsFilterType>()
				.ResolveAsync<BoardLabelsResolver>();
		}
	}
}