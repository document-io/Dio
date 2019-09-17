using GraphQL.Types;

namespace DocumentIO
{
	public class DeleteInviteGraphType : ObjectGraphType<DeleteInviteModel>
	{
		public DeleteInviteGraphType()
		{
			Name = "DeleteInvite";

			Field(x => x.Id);
		}
	}
}