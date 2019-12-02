namespace DocumentIO
{
	public class CreateFileType : DocumentIOInputGraphType<File>
	{
		public CreateFileType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
		}
	}
}