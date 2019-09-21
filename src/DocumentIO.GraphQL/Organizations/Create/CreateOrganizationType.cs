using System.Collections.Generic;
using GraphQL.Types;

namespace DocumentIO
{
	public class CreateOrganizationType : DocumentIOInputGraphType<Organization>
	{
		public CreateOrganizationType()
		{
			Field(x => x.Name);

			NonNullField<ListGraphType<CreateAccountType>, IEnumerable<Account>>("accounts");
		}
	}
}