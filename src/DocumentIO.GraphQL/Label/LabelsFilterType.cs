namespace DocumentIO
{
	public class LabelsFilterType : GraphQLFilterType<Label, LabelsFilter>
	{
		public LabelsFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Name, nullable: true);
			Field(x => x.Description, nullable: true);
			Field(x => x.Color, nullable: true);
		}
	}
}