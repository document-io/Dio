using System;
using System.Collections.Generic;
using System.Linq;
using GraphQL.DataLoader;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
    public class ReadLabelType : ObjectGraphType<Label>
    {
        public ReadLabelType(IDataLoaderContextAccessor accessor)
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Description);
            Field(x => x.Color);

            Field<ReadBoardType, Board>("board")
                .ResolveAsync(context =>
                {
                    var databaseContext = context.GetDatabaseContext();

                    var loader = accessor.Context.GetOrAddBatchLoader<Guid, Board>(
                        "LabelBoard",
                        async ids => await databaseContext.Labels
                            .Include(label => label.Board)
                            .Where(label => ids.Contains(label.Id))
                            .ToDictionaryAsync(label => label.Id, label => label.Board));

                    return loader.LoadAsync(context.Source.Id);
                });

            Field<ListGraphType<ReadCardType>, IEnumerable<Card>>("cards")
                .ResolveAsync(async context =>
                {
                    var databaseContext = context.GetDatabaseContext();

                    var loader = accessor.Context.GetOrAddCollectionBatchLoader<Guid, CardLabel>(
                        "LabelCards",
                        async ids => await databaseContext.CardLabels
                            .Include(cardLabel => cardLabel.Card)
                            .Where(cardLabel => ids.Contains(cardLabel.LabelId))
                            .ToListAsync(),
                        cardLabel => cardLabel.LabelId);

                    var cardLabels = await loader.LoadAsync(context.Source.Id);

                    return cardLabels.Select(cardLabel => cardLabel.Card).ToList();
                });
        }
    }
}