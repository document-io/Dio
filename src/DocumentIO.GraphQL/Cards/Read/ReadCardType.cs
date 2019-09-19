using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadCardType : ObjectGraphType<Card>
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
			
			Field<ListGraphType<ReadLabelType>, IEnumerable<Label>>("labels")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardLabel>(
						"CardLabels",
						async ids => await databaseContext.CardLabels
							.Include(cardLabel => cardLabel.Label)
							.Where(cardLabel => ids.Contains(cardLabel.CardId))
							.ToListAsync(),
						cardLabel => cardLabel.CardId);

					var cardLabels = await loader.LoadAsync(context.Source.Id);

					return cardLabels.Select(cardLabel => cardLabel.Label).ToList();
				});

			Field<ListGraphType<ReadAccountType>, IEnumerable<Account>>("assignments")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAssignment>(
						"CardAssignments",
						async ids => await databaseContext.CardAssignments
							.Include(cardLabel => cardLabel.Account)
							.Where(cardLabel => ids.Contains(cardLabel.CardId))
							.ToListAsync(),
						cardLabel => cardLabel.CardId);

					var cardLabels = await loader.LoadAsync(context.Source.Id);

					return cardLabels.Select(cardLabel => cardLabel.Account).ToList();
				});

			Field<ListGraphType<ReadCommentType>, IEnumerable<CardComment>>("comments")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardComment>(
						"CardComments",
						async ids => await databaseContext.CardComments
							.Where(cardLabel => ids.Contains(cardLabel.CardId))
							.ToListAsync(),
						cardLabel => cardLabel.CardId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadAttachmentType>, IEnumerable<CardAttachment>>("attachments")
				.Argument<AttachmentFilterType>("filter", q => q.DefaultValue = new AttachmentFilter())
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetArgument<AttachmentFilter>("filter");

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAttachment>(
						"CardAttachment",
						async ids =>
							await filter.Filter(databaseContext.CardAttachments
								.Where(cardLabel => ids.Contains(cardLabel.CardId)))
								.ToListAsync(),
						cardLabel => cardLabel.CardId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadEventType>, IEnumerable<CardEvent>>("events")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardEvent>(
						"CardEvent",
						async ids => await databaseContext.CardEvents
							.Where(cardLabel => ids.Contains(cardLabel.CardId))
							.ToListAsync(),
						cardLabel => cardLabel.CardId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}