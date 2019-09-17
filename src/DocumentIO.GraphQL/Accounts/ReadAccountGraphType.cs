using GraphQL.Types;

namespace DocumentIO
{
	public class ReadAccountGraphType : ObjectGraphType<ReadAccountModel>
	{
		public ReadAccountGraphType()
		{
			Field(x => x.Id);
			Field(x => x.Email);
			Field(x => x.FirstName);
			Field(x => x.MiddleName);
			Field(x => x.LastName);
			Field(x => x.CreatedAt);
		}
	}
}