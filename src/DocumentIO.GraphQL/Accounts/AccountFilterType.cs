using GraphQL.Types;

namespace DocumentIO
{
	public class AccountFilterType : InputObjectGraphType<AccountFilter>
	{
		public AccountFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.Role, nullable: true);
			Field(x => x.Email, nullable: true);
			Field(x => x.FirstName, nullable: true);
			Field(x => x.MiddleName, nullable: true);
			Field(x => x.LastName, nullable: true);
		}
	}
}