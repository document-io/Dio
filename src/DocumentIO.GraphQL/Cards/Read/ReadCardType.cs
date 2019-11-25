namespace DocumentIO
{
	public class ReadCardType : DocumentIOGraphType<Card>
	{
		public ReadCardType()
		{
			Interface<SearchInterface>();

			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Order);
			Field(x => x.CreatedAt);
			NullField(x => x.UpdatedAt);
			NullField(x => x.DueDate);
			NullField(x => x.Content);
			NullField(x => x.Description);

			NonNullDocumentIOField<ReadColumnType, Column>("column")
				.AllowUser()
				.ResolveAsync<CardColumnResolver>();

			DocumentIOListField<ReadLabelType, Label>("labels")
				.AllowUser()
				.Filtered<LabelsFilterType>()
				.ResolveAsync<CardLabelsResolver>();

			DocumentIOListField<ReadAccountType, Account>("assignments")
				.AllowUser()
				.Filtered<AccountsFilterType>()
				.ResolveAsync<CardAssignmentsResolver>();

			DocumentIOListField<ReadCommentType, CardComment>("comments")
				.AllowUser()
				.Filtered<CommentsFilterType>()
				.ResolveAsync<CardCommentsResolver>();

			DocumentIOListField<ReadAttachmentType, CardAttachment>("attachments")
				.AllowUser()
				.Filtered<AttachmentsFilterType>()
				.ResolveAsync<CardAttachmentsResolver>();

			DocumentIOListField<ReadEventType, CardEvent>("events")
				.AllowUser()
				.Filtered<EventsFilterType>()
				.ResolveAsync<CardEventsResolver>();
		}
	}
}