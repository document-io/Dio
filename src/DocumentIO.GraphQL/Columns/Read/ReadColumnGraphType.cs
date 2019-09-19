using GraphQL.Types;

namespace DocumentIO
{
	public class ReadColumnGraphType : ObjectGraphType<ReadColumnModel>
	{
		public ReadColumnGraphType()
		{
			Name = "ReadColumn";

			Field(x => x.Id);
			Field(x => x.BoardId);
			Field(x => x.Name);
			Field(x => x.Order);
		}
	}
}