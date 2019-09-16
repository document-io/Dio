using GraphQL.Types;

namespace DocumentIO
{
	public class UpdateAccountGraphType : InputObjectGraphType<UpdateAccountDto>
	{
		public UpdateAccountGraphType()
		{
			Name = "UpdateAccount";

			Field(a => a.Email, nullable: true).Name("email");
			Field(a => a.Password, nullable: true).Name("password");
			Field(a => a.FirstName, nullable: true).Name("firstName");
			Field(a => a.MiddleName, nullable: true).Name("middleName");
			Field(a => a.LastName, nullable: true).Name("lastName");
		}
	}
}