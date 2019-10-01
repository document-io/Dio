namespace DocumentIO
{
	public class ReadBoardType : DocumentIOGraphType<Board>
	{
		public ReadBoardType()
		{
			Interface<SearchInterface>();

			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.CreatedAt);

			NonNullDocumentIOField<ReadOrganizationType, Organization>("organization")
				.AllowUser()
				.ResolveAsync<BoardOrganizationResolver>();

			DocumentIOListField<ReadColumnType, Column>("columns")
				.AllowUser()
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<BoardColumnsResolver>();

			DocumentIOListField<ReadLabelType, Label>("labels")
				.AllowUser()
				.Filtered<LabelsFilterType>()
				.ResolveAsync<BoardLabelsResolver>();
		}
	}
}