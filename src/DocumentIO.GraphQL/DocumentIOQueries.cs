using System.Collections.Generic;
using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOQueries : DocumentIOGraphType<object>
	{
		public DocumentIOQueries()
		{
			Name = "Queries";

			DocumentIOField<ReadOrganizationType, Organization>("organization")
				.ResolveAsync<QueryOrganizationResolver>();

			DocumentIOField<ListGraphType<ReadAccountType>, IEnumerable<Account>>("accounts")
				.Filtered<AccountFilterType>()
				.ResolveAsync<QueryAccountsResolver>();

			DocumentIOField<ListGraphType<ReadAttachmentType>, IEnumerable<CardAttachment>>("attachments")
				.Filtered<AttachmentFilterType>()
				.ResolveAsync<QueryAttachmentsResolver>();

			DocumentIOField<ListGraphType<ReadBoardType>, IEnumerable<Board>>("boards")
				.Filtered<BoardsFilterType>()
				.ResolveAsync<QueryBoardsResolver>();

			DocumentIOField<ListGraphType<ReadColumnType>, IEnumerable<Column>>("columns")
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<QueryColumnsResolver>();

			DocumentIOField<ListGraphType<ReadCardType>, IEnumerable<Card>>("cards")
				.Filtered<CardsFilterType>()
				.ResolveAsync<QueryCardsResolver>();

			DocumentIOField<ListGraphType<ReadCommentType>, IEnumerable<CardComment>>("comments")
				.Filtered<CommentsFilterType>()
				.ResolveAsync<QueryCommentsResolver>();

			DocumentIOField<ListGraphType<ReadEventType>, IEnumerable<CardEvent>>("events")
				.Filtered<EventsFilterType>()
				.ResolveAsync<QueryEventsResovler>();

			DocumentIOField<ListGraphType<ReadInviteType>, IEnumerable<Invite>>("invites")
				.Filtered<InviteFilterType>()
				.ResolveAsync<QueryInvitesResovler>();

			DocumentIOField<ListGraphType<ReadLabelType>, IEnumerable<Label>>("labels")
				.Filtered<LabelsFilterType>()
				.ResolveAsync<QueryLabelsResovler>();
		}
	}
}