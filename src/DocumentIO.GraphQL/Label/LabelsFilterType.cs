namespace DocumentIO
{
	public class LabelsFilterType : DocumentIOFilterType<Label, LabelsFilter>
	{
		public LabelsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Name);
			NullField(x => x.Description);
			NullField(x => x.Color);
		}
	}
}