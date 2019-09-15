using System;

namespace DocumentIO.Web
{
	public class CardModel
	{
		public CardModel(Card card)
		{
			Id = card.Id;

			Name = card.Name;
			Position = card.Position;
			DueDate = card.DueDate;
			Markdown = card.Markdown;
		}

		public int Id { get; }

		public string Name { get; }
		public int Position { get; }
		public DateTime? DueDate { get; }

		public string Markdown { get; }
	}
}