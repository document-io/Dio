using GraphQL.Types;

namespace DocumentIO
{
	public class CreateAccountGraphType : InputObjectGraphType<CreateAccountDto>
	{
		public CreateAccountGraphType()
		{
			Name = "CreateAccount";

			Field(a => a.Email).Name("email");
			Field(a => a.Password).Name("password");
			Field(a => a.FirstName).Name("firstName");
			Field(a => a.MiddleName).Name("middleName");
			Field(a => a.LastName).Name("lastName");
		}
	}
}