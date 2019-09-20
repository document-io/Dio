using System.Collections.Generic;
using GraphQL.Types;

namespace DocumentIO
{
	public class ReadCardType : DocumentIOGraphType<Card>
	{
		public ReadCardType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Order);
			Field(x => x.DueDate, nullable: true);
			Field(x => x.Content);

			DocumentIOField<ReadColumnType, Column>("column")
				.ResolveAsync<CardColumnResolver>();

			DocumentIOField<ListGraphType<ReadLabelType>, IEnumerable<Label>>("labels")
				.Filtered<LabelsFilterType>()
				.ResolveAsync<CardLabelsResolver>();

			DocumentIOField<ListGraphType<ReadAccountType>, IEnumerable<Account>>("assignments")
				.Filtered<AccountFilterType>()
				.ResolveAsync<CardAssignmentsResolver>();

			DocumentIOField<ListGraphType<ReadCommentType>, IEnumerable<CardComment>>("comments")
				.Filtered<CommentsFilterType>()
				.ResolveAsync<CardCommentsResolver>();

			DocumentIOField<ListGraphType<ReadAttachmentType>, IEnumerable<CardAttachment>>("attachments")
				.Filtered<AttachmentFilterType>()
				.ResolveAsync<CardAttachmentsResolver>();

			DocumentIOField<ListGraphType<ReadEventType>, IEnumerable<CardEvent>>("events")
				.Filtered<EventsFilterType>()
				.ResolveAsync<CardEventsResolver>();
		}
	}
}