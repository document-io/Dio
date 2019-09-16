using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOQuery : ObjectGraphType
	{
		public DocumentIOQuery()
		{
			Name = "Query";

			this.AddOrganizationQueries();
			this.AddInviteQueries();
		}
	}
}