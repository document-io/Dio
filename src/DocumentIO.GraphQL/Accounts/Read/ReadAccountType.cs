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

			DocumentIOListField<ReadCardType, Card>("assignments")
				.Filtered<CardsFilterType>()
				.ResolveAsync<AccountAssignmentsResolver>();

			DocumentIOListField<ReadCommentType, CardComment>("comments")
				.Filtered<CommentsFilterType>()
				.ResolveAsync<AccountCommentsResolver>();

			DocumentIOListField<ReadAttachmentType, CardAttachment>("attachments")
				.Filtered<AttachmentFilterType>()
				.ResolveAsync<AccountAttachmentsResolver>();

			DocumentIOListField<ReadEventType, CardEvent>("events")
				.Filtered<EventsFilterType>()
				.ResolveAsync<AccountEventsResolver>();
		}
	}
}