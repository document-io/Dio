namespace DocumentIO
{
	public class UpdateFileType : DocumentIOInputGraphType<File>
	{
		public UpdateFileType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
		}
	}
}