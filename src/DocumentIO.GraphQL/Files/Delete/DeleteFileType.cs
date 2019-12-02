namespace DocumentIO
{
	public class DeleteFileType : DocumentIOInputGraphType<File>
	{
		public DeleteFileType()
		{
			Field(x => x.Id);
		}
	}
}