using System.Collections.Generic;
using System.Linq;
using GraphQL.Types;
using GraphQL.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentIO
{
	public class DocumentIOQuery : ObjectGraphType
	{
		public DocumentIOQuery()
		{
			Name = "Query";

			Field<ListGraphType<ReadAccountGraphType>, List<ReadAccountDto>>()
				.Name("accounts")
				.AuthorizeWith(Roles.User)
				.ResolveAsync(async context =>
				{
					var databaseContext = context.GetUserContext()
						.ServiceProvider
						.GetRequiredService<DatabaseContext>();

					return await databaseContext.Accounts
						.Select(account => new ReadAccountDto
						{
							Id = account.Id,
							Email = account.Email,
							FirstName = account.FirstName,
							LastName = account.LastName,
							MiddleName = account.MiddleName
						})
						.ToListAsync();
				});
		}
	}
}