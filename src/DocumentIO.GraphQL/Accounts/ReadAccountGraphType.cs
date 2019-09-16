using GraphQL.Types;

namespace DocumentIO
{
	public class ReadAccountGraphType : ObjectGraphType<ReadAccountDto>
	{
		public ReadAccountGraphType()
		{
			Name = "ReadAccount";

			Field(a => a.Id).Name("id");
			Field(a => a.Email).Name("email");
			Field(a => a.FirstName).Name("firstName");
			Field(a => a.MiddleName).Name("middleName");
			Field(a => a.LastName).Name("lastName");
		}
	}
}