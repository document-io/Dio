using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOMutation : ObjectGraphType
	{
		public DocumentIOMutation()
		{
			Name = "Mutation";

			this.AddOrganizationMutations();
			this.AddInviteMutations();
		}
	}
}