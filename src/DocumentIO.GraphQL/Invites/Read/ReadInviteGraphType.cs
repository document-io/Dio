using GraphQL.Types;

namespace DocumentIO
{
	public class ReadInviteGraphType : ObjectGraphType<ReadInviteModel>
	{
		public ReadInviteGraphType()
		{
			Name = "ReadInvite";

			Field(x => x.Id);
			Field(x => x.Role);
			Field(x => x.Email);
			Field(x => x.Identifier);

			Field(x => x.Description);
			Field(x => x.CreatedAt);
			Field(x => x.DueDate, nullable: true);

			Field(x => x.AccountId);
		}
	}
}