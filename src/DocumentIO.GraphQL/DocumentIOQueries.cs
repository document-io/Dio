using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOQueries : DocumentIOGraphType<object>
	{
		public DocumentIOQueries()
		{
			Name = "Queries";

			NonNullDocumentIOField<StringGraphType, string>("version")
				.ResolveAsync<QueryVersionResolver>();

			NonNullDocumentIOField<ReadOrganizationType, Organization>("organization")
				.Authorize(Roles.User)
				.ResolveAsync<QueryOrganizationResolver>();

			DocumentIOListField<ReadAccountType, Account>("accounts")
				.Authorize(Roles.User)
				.Filtered<AccountFilterType>()
				.ResolveAsync<QueryAccountsResolver>();

			DocumentIOListField<ReadAttachmentType, CardAttachment>("attachments")
				.Authorize(Roles.User)
				.Filtered<AttachmentFilterType>()
				.ResolveAsync<QueryAttachmentsResolver>();

			DocumentIOListField<ReadBoardType, Board>("boards")
				.Authorize(Roles.User)
				.Filtered<BoardsFilterType>()
				.ResolveAsync<QueryBoardsResolver>();

			DocumentIOListField<ReadColumnType, Column>("columns")
				.Authorize(Roles.User)
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<QueryColumnsResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.Authorize(Roles.User)
				.Filtered<CardsFilterType>()
				.ResolveAsync<QueryCardsResolver>();

			DocumentIOListField<ReadCommentType, CardComment>("comments")
				.Authorize(Roles.User)
				.Filtered<CommentsFilterType>()
				.ResolveAsync<QueryCommentsResolver>();

			DocumentIOListField<ReadEventType, CardEvent>("events")
				.Authorize(Roles.User)
				.Filtered<EventsFilterType>()
				.ResolveAsync<QueryEventsResovler>();

			DocumentIOListField<ReadInviteType, Invite>("invites")
				.Authorize(Roles.Admin)
				.Filtered<InviteFilterType>()
				.ResolveAsync<QueryInvitesResovler>();

			DocumentIOListField<ReadLabelType, Label>("labels")
				.Authorize(Roles.User)
				.Filtered<LabelsFilterType>()
				.ResolveAsync<QueryLabelsResovler>();

			DocumentIOListField<SearchInterface, Search>("search")
				.Authorize(Roles.User)
				.Filtered<SearchFilterType>()
				.ResolveAsync<SearchResolver>();
		}
	}
}