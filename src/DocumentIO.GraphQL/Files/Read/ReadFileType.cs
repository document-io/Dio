namespace DocumentIO
{
	public class ReadFileType : DocumentIOGraphType<File>
	{
		public ReadFileType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			NullField(x => x.FileName);
			NullField(x => x.ContentType);
			NullField(x => x.ContentDisposition);
			NullField(x => x.Length);
		}
	}
}