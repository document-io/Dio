using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadCardType : DocumentIOGraphType<Card>
	{
		public ReadCardType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Name);
			Field(x => x.Order);
			Field(x => x.DueDate, nullable: true);
			Field(x => x.Markdown);

			Field<ReadColumnType, Column>("column")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Column>(
						"CardColumn",
						async ids => await databaseContext.Cards
							.Include(card => card.Column)
							.Where(card => ids.Contains(card.Id))
							.ToDictionaryAsync(card => card.Id, card => card.Column));

					return loader.LoadAsync(context.Source.Id);
				});
			
			FilteredField<ListGraphType<ReadLabelType>, IEnumerable<Label>, LabelsFilterType>("labels")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Card, LabelsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardLabel>(
						"CardLabels",
						async ids =>
							await filter.Filtered(
									databaseContext.Labels,
									labels => labels.SelectMany(label => label.Cards)
										.Include(cardLabel => cardLabel.Label)
										.Where(cardLabel => ids.Contains(cardLabel.CardId)))
								.ToListAsync(),
						cardLabel => cardLabel.CardId);

					var cardLabels = await loader.LoadAsync(context.Source.Id);

					return cardLabels.Select(cardLabel => cardLabel.Label).ToList();
				});

			FilteredField<ListGraphType<ReadAccountType>, IEnumerable<Account>, AccountFilterType>("assignments")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Card, AccountFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAssignment>(
						"AccountAssignments",
						async ids => 
							await filter.Filtered(
									databaseContext.Accounts,
									accounts => accounts.SelectMany(account => account.Assignments)
										.Include(cardLabel => cardLabel.Account)
										.Where(cardLabel => ids.Contains(cardLabel.CardId)))
								.ToListAsync(),
						cardLabel => cardLabel.CardId);

					var cardLabels = await loader.LoadAsync(context.Source.Id);

					return cardLabels.Select(cardLabel => cardLabel.Account).ToList();
				});

			FilteredField<ListGraphType<ReadCommentType>, IEnumerable<CardComment>, CommentsFilterType>("comments")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Card, CommentsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardComment>(
						"CardComments",
						async ids =>
							await filter.Filtered(
									databaseContext.CardComments,
									comments => comments.Where(comment => ids.Contains(comment.CardId)))
								.ToListAsync(),
						cardLabel => cardLabel.CardId);

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadAttachmentType>, IEnumerable<CardAttachment>, AttachmentFilterType>("attachments")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Card, AttachmentFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAttachment>(
						"CardAttachment",
						async ids =>
							await filter.Filtered(
									databaseContext.CardAttachments,
									attachments => attachments.Where(attachment => ids.Contains(attachment.CardId)))
								.ToListAsync(),
						cardLabel => cardLabel.CardId);

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadEventType>, IEnumerable<CardEvent>, EventsFilterType>("events")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Card, EventsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardEvent>(
						"CardEvent",
						async ids =>
							await filter.Filtered(
									databaseContext.CardEvents,
									events => events.Where(@event => ids.Contains(@event.CardId)))
								.ToListAsync(),
						cardLabel => cardLabel.CardId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}