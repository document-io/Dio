using GraphQL.Types;

namespace DocumentIO
{
	public class SearchInterface : InterfaceGraphType
	{
		public SearchInterface()
		{
			Field<StringGraphType, string>("name");
		}
	}
}