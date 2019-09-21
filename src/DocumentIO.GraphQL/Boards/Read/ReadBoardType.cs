namespace DocumentIO
{
	public class ReadBoardType : DocumentIOGraphType<Board>
	{
		public ReadBoardType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.CreatedAt);

			DocumentIOField<ReadOrganizationType, Organization>("organization")
				.ResolveAsync<BoardOrganizationResolver>();

			DocumentIOListField<ReadColumnType, Column>("columns")
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<BoardColumnsResolver>();

			DocumentIOListField<ReadLabelType, Label>("labels")
				.Filtered<LabelsFilterType>()
				.ResolveAsync<BoardLabelsResolver>();
		}
	}
}