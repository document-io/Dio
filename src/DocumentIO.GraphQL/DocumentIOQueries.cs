using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOQueries : ObjectGraphType
	{
		public DocumentIOQueries()
		{
			Name = "Query";

			this.AddOrganizationQueries();
			this.AddInviteQueries();
			this.AddAccountQueries();
			this.AddBoardsQueries();
			this.AddColumnQueries();
		}
	}
}