using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public static class OrganizationExtensions
	{
		public static async Task<Organization> GetByAccountId(this IQueryable<Organization> organizations, Guid accountId)
		{
			return await  organizations
				.SingleAsync(organization =>
					organization.Accounts.Any(
						account => account.Id == accountId));
		}
	}
}