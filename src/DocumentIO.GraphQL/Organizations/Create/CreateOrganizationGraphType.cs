using GraphQL.Types;

namespace DocumentIO
{
	public class CreateOrganizationGraphType : InputObjectGraphType<CreateOrganizationModel>
	{
		public CreateOrganizationGraphType()
		{
			Name = "CreateOrganization";

			Field(o => o.Name);
			Field(o => o.Email);
			Field(o => o.Password);
			Field(o => o.FirstName);
			Field(o => o.MiddleName);
			Field(o => o.LastName);
		}
	}
}