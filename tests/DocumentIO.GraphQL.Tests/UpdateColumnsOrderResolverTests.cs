using System;
using Xunit;

namespace DocumentIO
{
	public class UpdateColumnsOrderResolverTests
	{
		private readonly UpdateColumnResolver resolver;

		public UpdateColumnsOrderResolverTests()
		{
			resolver = new UpdateColumnResolver(null);
		}

		[Fact]
		public void MoveSwitchColumns_1()
		{
			var column1 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var column2 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var model = new Column
			{
				Id = column2.Id,
				Order = 1
			};

			var columns = new[] {column1, column2};

			resolver.UpdateColumnsOrder(columns, model);

			Assert.Equal(2, column1.Order);
			Assert.Equal(1, column2.Order);
		}

		[Fact]
		public void MoveSwitchColumns_2()
		{
			var column1 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var column2 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var model = new Column
			{
				Id = column1.Id,
				Order = 2
			};

			var columns = new[] {column1, column2};

			resolver.UpdateColumnsOrder(columns, model);

			Assert.Equal(2, column1.Order);
			Assert.Equal(1, column2.Order);
		}

		[Fact]
		public void MoveForwardToMiddle()
		{
			var column1 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var column2 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var column3 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var column4 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Column
			{
				Id = column2.Id,
				Order = 3
			};

			var columns = new[] {column1, column2, column3, column4};

			resolver.UpdateColumnsOrder(columns, model);

			Assert.Equal(1, column1.Order);
			Assert.Equal(3, column2.Order);
			Assert.Equal(2, column3.Order);
			Assert.Equal(4, column4.Order);
		}

		[Fact]
		public void MoveMiddleToForward()
		{
			var column1 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var column2 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var column3 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var model = new Column
			{
				Id = column2.Id,
				Order = 3
			};

			var columns = new[] {column1, column2, column3};

			resolver.UpdateColumnsOrder(columns, model);

			Assert.Equal(1, column1.Order);
			Assert.Equal(3, column2.Order);
			Assert.Equal(2, column3.Order);
		}

		[Fact]
		public void MoveForwardToEnd()
		{
			var column1 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var column2 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var column3 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var column4 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Column
			{
				Id = column1.Id,
				Order = 4
			};

			var columns = new[] {column1, column2, column3, column4};

			resolver.UpdateColumnsOrder(columns, model);

			Assert.Equal(4, column1.Order);
			Assert.Equal(1, column2.Order);
			Assert.Equal(2, column3.Order);
			Assert.Equal(3, column4.Order);
		}

		[Fact]
		public void MoveBackwardToMiddle()
		{
			var column1 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var column2 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var column3 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var column4 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Column
			{
				Id = column3.Id,
				Order = 2
			};

			var columns = new[] {column1, column2, column3, column4};

			resolver.UpdateColumnsOrder(columns, model);

			Assert.Equal(1, column1.Order);
			Assert.Equal(3, column2.Order);
			Assert.Equal(2, column3.Order);
			Assert.Equal(4, column4.Order);
		}

		[Fact]
		public void MoveBackwardToStart()
		{
			var column1 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 1
			};

			var column2 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 2
			};

			var column3 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 3
			};

			var column4 = new Column
			{
				Id = Guid.NewGuid(),
				Order = 4
			};

			var model = new Column
			{
				Id = column4.Id,
				Order = 1
			};

			var columns = new[] {column1, column2, column3, column4};

			resolver.UpdateColumnsOrder(columns, model);

			Assert.Equal(2, column1.Order);
			Assert.Equal(3, column2.Order);
			Assert.Equal(4, column3.Order);
			Assert.Equal(1, column4.Order);
		}
	}
}