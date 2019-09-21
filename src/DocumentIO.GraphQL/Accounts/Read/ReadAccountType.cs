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
				.Authorize(Roles.Admin)
				.ResolveAsync<AccountInviteResolver>();

			DocumentIOField<ReadOrganizationType, Organization>("organization")
				.Authorize(Roles.User)
				.ResolveAsync<AccountOrganizationResolver>();

			DocumentIOListField<ReadCardType, Card>("assignments")
				.Authorize(Roles.User)
				.Filtered<CardsFilterType>()
				.ResolveAsync<AccountAssignmentsResolver>();

			DocumentIOListField<ReadCommentType, CardComment>("comments")
				.Authorize(Roles.User)
				.Filtered<CommentsFilterType>()
				.ResolveAsync<AccountCommentsResolver>();

			DocumentIOListField<ReadAttachmentType, CardAttachment>("attachments")
				.Authorize(Roles.User)
				.Filtered<AttachmentFilterType>()
				.ResolveAsync<AccountAttachmentsResolver>();

			DocumentIOListField<ReadEventType, CardEvent>("events")
				.Authorize(Roles.User)
				.Filtered<EventsFilterType>()
				.ResolveAsync<AccountEventsResolver>();
		}
	}
}