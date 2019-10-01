using GraphQL.Types;

namespace DocumentIO
{
	public class ReadCountType : DocumentIOGraphType<object>
	{
		public ReadCountType()
		{
			DocumentIOField<IntGraphType, int>("accounts")
				.AllowUser()
				.Filtered<AccountsFilterType>()
				.ResolveAsync<AccountsCountResolver>();

			DocumentIOField<IntGraphType, int>("attachments")
				.AllowUser()
				.Filtered<AttachmentsFilterType>()
				.ResolveAsync<AttachmentsCountResolver>();

			DocumentIOField<IntGraphType, int>("boards")
				.AllowUser()
				.Filtered<BoardsFilterType>()
				.ResolveAsync<BoardsCountResolver>();

			DocumentIOField<IntGraphType, int>("cards")
				.AllowUser()
				.Filtered<CardsFilterType>()
				.ResolveAsync<CardsCountResolver>();

			DocumentIOField<IntGraphType, int>("columns")
				.AllowUser()
				.Filtered<ColumnsFilterType>()
				.ResolveAsync<ColumnsCountResolver>();

			DocumentIOField<IntGraphType, int>("comments")
				.AllowUser()
				.Filtered<CommentsFilterType>()
				.ResolveAsync<CommentsCountResolver>();

			DocumentIOField<IntGraphType, int>("events")
				.AllowUser()
				.Filtered<EventsFilterType>()
				.ResolveAsync<EventsCountResolver>();

			DocumentIOField<IntGraphType, int>("invites")
				.AllowUser()
				.Filtered<InvitesFilterType>()
				.ResolveAsync<InvitesCountResolver>();

			DocumentIOField<IntGraphType, int>("labels")
				.AllowUser()
				.Filtered<LabelsFilterType>()
				.ResolveAsync<LabelsCountResolver>();
		}
	}
}