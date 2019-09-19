using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOMutations : ObjectGraphType
	{
		public DocumentIOMutations()
		{
			Name = "Mutation";

			this.AddOrganizationMutations();
			this.AddInviteMutations();
			this.AddAccountMutations();
			this.AddBoardsMutations();
			this.AddColumnMutations();
		}
	}
}