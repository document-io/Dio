using System;
using Xunit;

namespace DocumentIO
{
	public class UpdateCardsOrderResolverTests
	{
		private readonly UpdateCardResolver resolver;

		public UpdateCardsOrderResolverTests()
		{
			resolver = new UpdateCardResolver(null);
		}

		[Fact]
		public void MoveSwitchCards_1()
		{
			var card1 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var card2 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var model = new Card
			{
				Id = card2.Id,
				Order = 1
			};

			var cards = new[] { card1, card2 };

			resolver.UpdateCardsOrder(cards, model);

			Assert.Equal(2, card1.Order);
			Assert.Equal(1, card2.Order);
		}

		[Fact]
		public void MoveSwitchCards_2()
		{
			var card1 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var card2 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var model = new Card
			{
				Id = card1.Id,
				Order = 2
			};

			var cards = new[] { card1, card2 };

			resolver.UpdateCardsOrder(cards, model);

			Assert.Equal(2, card1.Order);
			Assert.Equal(1, card2.Order);
		}

		[Fact]
		public void MoveForwardToMiddle()
		{
			var card1 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var card2 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var card3 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var card4 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Card
			{
				Id = card2.Id,
				Order = 3
			};

			var cards = new[] { card1, card2, card3, card4 };

			resolver.UpdateCardsOrder(cards, model);

			Assert.Equal(1, card1.Order);
			Assert.Equal(3, card2.Order);
			Assert.Equal(2, card3.Order);
			Assert.Equal(4, card4.Order);
		}
		
		[Fact]
		public void MoveMiddleToForward()
		{
			var card1 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var card2 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var card3 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var model = new Card
			{
				Id = card2.Id,
				Order = 3
			};

			var cards = new[] { card1, card2, card3 };

			resolver.UpdateCardsOrder(cards, model);

			Assert.Equal(1, card1.Order);
			Assert.Equal(3, card2.Order);
			Assert.Equal(2, card3.Order);
		}

		[Fact]
		public void MoveForwardToEnd()
		{
			var card1 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var card2 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var card3 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var card4 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Card
			{
				Id = card1.Id,
				Order = 4
			};

			var cards = new[] { card1, card2, card3, card4 };

			resolver.UpdateCardsOrder(cards, model);

			Assert.Equal(4, card1.Order);
			Assert.Equal(1, card2.Order);
			Assert.Equal(2, card3.Order);
			Assert.Equal(3, card4.Order);
		}

		[Fact]
		public void MoveBackwardToMiddle()
		{
			var card1 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var card2 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var card3 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 3
			};
			
			var card4 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Card
			{
				Id = card3.Id,
				Order = 2
			};

			var cards = new[] { card1, card2, card3, card4 };

			resolver.UpdateCardsOrder(cards, model);

			Assert.Equal(1, card1.Order);
			Assert.Equal(3, card2.Order);
			Assert.Equal(2, card3.Order);
			Assert.Equal(4, card4.Order);
		}
		
		[Fact]
		public void MoveBackwardToStart()
		{
			var card1 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var card2 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var card3 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 3
			};
			
			var card4 = new Card
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Card
			{
				Id = card4.Id,
				Order = 1
			};

			var cards = new[] { card1, card2, card3, card4 };

			resolver.UpdateCardsOrder(cards, model);

			Assert.Equal(2, card1.Order);
			Assert.Equal(3, card2.Order);
			Assert.Equal(4, card3.Order);
			Assert.Equal(1, card4.Order);
		}
	}
}