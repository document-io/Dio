namespace DocumentIO
{
	public class ReadAccountType : DocumentIOGraphType<Account>
	{
		public ReadAccountType()
		{
			Field(x => x.Id);
			Field(x => x.Login);
			Field(x => x.Role);
			Field(x => x.Email);
			Field(x => x.FirstName);
			NullField(x => x.MiddleName);
			Field(x => x.LastName);
			Field(x => x.CreatedAt);

			NonNullDocumentIOField<ReadInviteType, Invite>("invite")
				.AllowAdmin()
				.ResolveAsync<AccountInviteResolver>();

			NonNullDocumentIOField<ReadOrganizationType, Organization>("organization")
				.AllowUser()
				.ResolveAsync<AccountOrganizationResolver>();

			DocumentIOListField<ReadCardType, Card>("assignments")
				.AllowUser()
				.Filtered<CardsFilterType>()
				.ResolveAsync<AccountAssignmentsResolver>();

			DocumentIOListField<ReadCommentType, CardComment>("comments")
				.AllowUser()
				.Filtered<CommentsFilterType>()
				.ResolveAsync<AccountCommentsResolver>();

			DocumentIOListField<ReadAttachmentType, CardAttachment>("attachments")
				.AllowUser()
				.Filtered<AttachmentsFilterType>()
				.ResolveAsync<AccountAttachmentsResolver>();

			DocumentIOListField<ReadEventType, CardEvent>("events")
				.AllowUser()
				.Filtered<EventsFilterType>()
				.ResolveAsync<AccountEventsResolver>();
		}
	}
}