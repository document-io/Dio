namespace DocumentIO
{
	public class UpdateLabelType : DocumentIOInputGraphType<Label>
	{
		public UpdateLabelType()
		{
			Field(x => x.Id);
			NullField(x => x.Name);
			NullField(x => x.Description);
			NullField(x => x.Color);
		}
	}
}