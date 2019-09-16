using GraphQL.Types;

namespace DocumentIO
{
	public class ReadOrganizationGraphType : ObjectGraphType<ReadOrganizationModel>
	{
		public ReadOrganizationGraphType()
		{
			Name = "ReadOrganization";

			Field(x => x.Id);
			Field(x => x.Name);
		}
	}
}