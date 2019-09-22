namespace DocumentIO
{
	public class ReadBoardType : DocumentIOGraphType<Board>
	{
		public ReadBoardType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.CreatedAt);

			NonNullDocumentIOField<ReadOrganizationType, Organization>("organization")
				.Authorize(Roles.User)
				.ResolveAsync<BoardOrganizationResolver>();

			DocumentIOListField<ReadColumnType, Column>("columns")
				.Authorize(Roles.User)
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<BoardColumnsResolver>();

			DocumentIOListField<ReadLabelType, Label>("labels")
				.Authorize(Roles.User)
				.Filtered<LabelsFilterType>()
				.ResolveAsync<BoardLabelsResolver>();
		}
	}
}