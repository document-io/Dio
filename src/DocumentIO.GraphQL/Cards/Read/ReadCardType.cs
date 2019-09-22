namespace DocumentIO
{
	public class ReadCardType : DocumentIOGraphType<Card>
	{
		public ReadCardType()
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Order);
			Field(x => x.CreatedAt);
			NullField(x => x.UpdatedAt);
			NullField(x => x.DueDate);
			Field(x => x.Content);

			DocumentIOField<ReadColumnType, Column>("column")
				.Authorize(Roles.User)
				.ResolveAsync<CardColumnResolver>();

			DocumentIOListField<ReadLabelType, Label>("labels")
				.Authorize(Roles.User)
				.Filtered<LabelsFilterType>()
				.ResolveAsync<CardLabelsResolver>();

			DocumentIOListField<ReadAccountType, Account>("assignments")
				.Authorize(Roles.User)
				.Filtered<AccountFilterType>()
				.ResolveAsync<CardAssignmentsResolver>();

			DocumentIOListField<ReadCommentType, CardComment>("comments")
				.Authorize(Roles.User)
				.Filtered<CommentsFilterType>()
				.ResolveAsync<CardCommentsResolver>();

			DocumentIOListField<ReadAttachmentType, CardAttachment>("attachments")
				.Authorize(Roles.User)
				.Filtered<AttachmentFilterType>()
				.ResolveAsync<CardAttachmentsResolver>();

			DocumentIOListField<ReadEventType, CardEvent>("events")
				.Authorize(Roles.User)
				.Filtered<EventsFilterType>()
				.ResolveAsync<CardEventsResolver>();
		}
	}
}