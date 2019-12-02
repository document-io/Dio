using System;
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

			DocumentIOField<GuidGraphType, Guid?>("accountId")
				.ResolveAsync<QueryAccountIdResolver>();

			NonNullDocumentIOField<ReadOrganizationType, Organization>("organization")
				.AllowUser()
				.ResolveAsync<QueryOrganizationResolver>();

			DocumentIOListField<ReadAccountType, Account>("accounts")
				.AllowUser()
				.Filtered<AccountsFilterType>()
				.ResolveAsync<QueryAccountsResolver>();

			DocumentIOListField<ReadAttachmentType, CardAttachment>("attachments")
				.AllowUser()
				.Filtered<AttachmentsFilterType>()
				.ResolveAsync<QueryAttachmentsResolver>();

			DocumentIOListField<ReadBoardType, Board>("boards")
				.AllowUser()
				.Filtered<BoardsFilterType>()
				.ResolveAsync<QueryBoardsResolver>();

			DocumentIOListField<ReadColumnType, Column>("columns")
				.AllowUser()
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<QueryColumnsResolver>();

			DocumentIOListField<ReadCardType, Card>("cards")
				.AllowUser()
				.Filtered<CardsFilterType>()
				.ResolveAsync<QueryCardsResolver>();

			DocumentIOListField<ReadCommentType, CardComment>("comments")
				.AllowUser()
				.Filtered<CommentsFilterType>()
				.ResolveAsync<QueryCommentsResolver>();

			DocumentIOListField<ReadEventType, CardEvent>("events")
				.AllowUser()
				.Filtered<EventsFilterType>()
				.ResolveAsync<QueryEventsResovler>();

			DocumentIOListField<ReadInviteType, Invite>("invites")
				.AllowAdmin()
				.Filtered<InvitesFilterType>()
				.ResolveAsync<QueryInvitesResovler>();

			DocumentIOListField<ReadLabelType, Label>("labels")
				.AllowUser()
				.Filtered<LabelsFilterType>()
				.ResolveAsync<QueryLabelsResovler>();

			DocumentIOListField<SearchInterface, Search>("search")
				.AllowUser()
				.Filtered<SearchFilterType>()
				.ResolveAsync<SearchResolver>();

			DocumentIOListField<ReadFileType, File>("files")
				.AllowUser()
				.Filtered<FilesFilterType>()
				.ResolveAsync<QueryFilesResolver>();

			DocumentIOField<ReadCountType, object>("count")
				.AllowUser()
				.ResolveAsync<CountResolver>();
		}
	}
}