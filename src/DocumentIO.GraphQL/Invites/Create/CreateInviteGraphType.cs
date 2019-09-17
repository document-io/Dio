using GraphQL.Types;

namespace DocumentIO
{
	public class CreateInviteGraphType : InputObjectGraphType<CreateInviteModel>
	{
		public CreateInviteGraphType()
		{
			Name = "CreateInvite";

			Field(x => x.Role);
			Field(x => x.Email);
			Field(x => x.Description);
			Field(x => x.DueDate, nullable: true);
		}
	}
}