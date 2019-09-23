namespace DocumentIO
{
	public class CreateLabelType : DocumentIOInputGraphType<Label>
	{
		public CreateLabelType()
		{
			Field(x => x.Name);
			Field(x => x.Description);
			Field(x => x.Color);
			Field(x => x.BoardId);
		}
	}
}