using System.Collections.Generic;
using GraphQL.Types;

namespace DocumentIO
{
	public class ReadAccountType : DocumentIOGraphType<Account>
	{
		public ReadAccountType()
		{
			Field(x => x.Id);
			Field(x => x.Role);
			Field(x => x.Email);
			Field(x => x.FirstName);
			Field(x => x.MiddleName);
			Field(x => x.LastName);
			Field(x => x.CreatedAt);

			DocumentIOField<ReadInviteType, Invite>("invite")
				.ResolveAsync<AccountInviteResolver>();

			DocumentIOField<ReadOrganizationType, Organization>("organization")
				.ResolveAsync<AccountOrganizationResolver>();

			DocumentIOField<ListGraphType<ReadCardType>, IEnumerable<Card>>("assignments")
				.Filtered<CardsFilterType>()
				.ResolveAsync<AccountAssignmentsResolver>();

			DocumentIOField<ListGraphType<ReadCommentType>, IEnumerable<CardComment>>("comments")
				.Filtered<CommentsFilterType>()
				.ResolveAsync<AccountCommentsResolver>();

			DocumentIOField<ListGraphType<ReadAttachmentType>, IEnumerable<CardAttachment>>("attachments")
				.Filtered<AttachmentFilterType>()
				.ResolveAsync<AccountAttachmentsResolver>();

			DocumentIOField<ListGraphType<ReadEventType>, IEnumerable<CardEvent>>("events")
				.Filtered<EventsFilterType>()
				.ResolveAsync<AccountEventsResolver>();
		}
	}
}