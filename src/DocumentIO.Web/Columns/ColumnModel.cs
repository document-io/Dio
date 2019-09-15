using System.Collections.Generic;
using System.Linq;

namespace DocumentIO.Web
{
	public class ColumnModel
	{
		public ColumnModel(Column column)
		{
			Id = column.Id;
			Name = column.Name;
			Position = column.Position;

			Cards = column.Cards.Select(card => new CardModel(card)).ToList();
		}

		public int Id { get; }
		public string Name { get; }
		public int Position { get; }

		public ICollection<CardModel> Cards { get; }
	}
}