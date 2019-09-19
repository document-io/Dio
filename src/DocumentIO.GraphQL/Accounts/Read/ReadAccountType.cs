using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class ReadAccountType : ObjectGraphType<Account>
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
							.Include(account => account.Organization)
							.Where(account => ids.Contains(account.Id))
							.ToDictionaryAsync(account => account.Id, account => account.Organization));

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadCardType>, IEnumerable<Card>>("assignments")
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAssignment>(
						"AccountCards",
						async ids => await databaseContext.CardAssignments
							.Include(cardLabel => cardLabel.Card)
							.Where(cardLabel => ids.Contains(cardLabel.AccountId))
							.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					var cardLabels = await loader.LoadAsync(context.Source.Id);

					return cardLabels.Select(cardLabel => cardLabel.Card).ToList();
				});

			Field<ListGraphType<ReadCommentType>, IEnumerable<CardComment>>("comments")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardComment>(
						"AccountComments",
						async ids => await databaseContext.CardComments
							.Where(cardLabel => ids.Contains(cardLabel.AccountId))
							.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadAttachmentType>, IEnumerable<CardAttachment>>("attachments")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardAttachment>(
						"AccountAttachments",
						async ids => await databaseContext.CardAttachments
							.Where(cardLabel => ids.Contains(cardLabel.AccountId))
							.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					return loader.LoadAsync(context.Source.Id);
				});

			Field<ListGraphType<ReadEventType>, IEnumerable<CardEvent>>("events")
				.ResolveAsync(context =>
				{
					var databaseContext = context.GetDatabaseContext();

					var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardEvent>(
						"AccountEvents",
						async ids => await databaseContext.CardEvents
							.Where(cardLabel => ids.Contains(cardLabel.AccountId))
							.ToListAsync(),
						cardLabel => cardLabel.AccountId);

					return loader.LoadAsync(context.Source.Id);
				});
		}
	}
}