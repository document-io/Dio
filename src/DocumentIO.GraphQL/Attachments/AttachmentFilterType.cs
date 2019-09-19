using GraphQL.Types;

namespace DocumentIO
{
	public class AttachmentFilterType : InputObjectGraphType<AttachmentFilter>
	{
		public AttachmentFilterType()
		{
			Field(x => x.Id, nullable: true);
			Field(x => x.MimeType, nullable: true);
		}
	}
}