using GraphQL.Types;

namespace DocumentIO
{
	public class DeleteAccountGraphType : ObjectGraphType<DeleteAccountDto>
	{
		public DeleteAccountGraphType()
		{
			Field(a => a.Id).Name("id");
		}
	}
}