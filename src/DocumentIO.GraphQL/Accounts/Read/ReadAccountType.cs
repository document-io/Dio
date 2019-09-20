using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadAccountType : DocumentIOGraphType<Account>
	{
		public ReadAccountType(IDataLoaderContextAccessor accessor)
		{
			Field(x => x.Id);
			Field(x => x.Role);
			Field(x => x.Email);
			Field(x => x.FirstName);
			Field(x => x.MiddleName);
			Field(x => x.LastName);
			Field(x => x.CreatedAt);

			Field<ReadInviteType, Invite>("invite")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Invite>(
						"AccountInvite",
						async ids => await databaseContext.Accounts
							.AsNoTracking()
							.Include(account => account.Invite)
							.Where(account => ids.Contains(account.Id))
							.ToDictionaryAsync(account => account.Id, account => account.Invite));

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ReadOrganizationType, Organization>("organization")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddBatchLoader<Guid, Organization>(
						"AccountOrganization",
						async ids => await databaseContext.Accounts
							.AsNoTracking()
							.Include(account => account.Organization)
							.Where(account => ids.Contains(account.Id))
							.ToDictionaryAsync(account => account.Id, account => account.Organization));

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadCardType>, IEnumerable<Card>, CardsFilterType>("assignments")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Account, CardsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAssignment>(
						"AccountCards",
						async ids =>
							await filter.Filtered(
									databaseContext.Cards.AsNoTracking(),
									cards => cards.SelectMany(card => card.Assignments)
										.Include(cardLabel => cardLabel.Card)
										.Where(cardLabel => ids.Contains(cardLabel.AccountId)))
								.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					var cardLabels = await loader.LoadAsync(context.Source.Id);

					return cardLabels.Select(cardLabel => cardLabel.Card).ToList();
				});

			FilteredField<ListGraphType<ReadCommentType>, IEnumerable<CardComment>, CommentsFilterType>("comments")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Account, CommentsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardComment>(
						"AccountComments",
						async ids => 
							await filter.Filtered(
									databaseContext.CardComments.AsNoTracking(),
									comments => comments.Where(cardLabel => ids.Contains(cardLabel.AccountId)))
								.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadAttachmentType>, IEnumerable<CardAttachment>, AttachmentFilterType>("attachments")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Account, AttachmentFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAttachment>(
						"AccountAttachments",
						async ids => await filter.Filtered(
								databaseContext.CardAttachments.AsNoTracking(),
								attachments => attachments.Where(cardLabel => ids.Contains(cardLabel.AccountId)))
							.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					return loader.LoadAsync(context.Source.Id);
				});

			FilteredField<ListGraphType<ReadEventType>, IEnumerable<CardEvent>, EventsFilterType>("events")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();
					var filter = context.GetFilter<Account, EventsFilter>();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardEvent>(
						"AccountEvents",
						async ids =>
							await filter.Filtered(
									databaseContext.CardEvents.AsNoTracking(),
									events => events.Where(cardLabel => ids.Contains(cardLabel.AccountId)))
								.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}