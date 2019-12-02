namespace DocumentIO
{
	public class FilesFilterType : DocumentIOInputGraphType<File>
	{
		public FilesFilterType()
		{
			Field(x => x.Id);
			
			// TODO: Фильтрация
		}
	}
}