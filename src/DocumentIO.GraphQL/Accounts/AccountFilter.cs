using System;
using System.Linq;
using System.Linq.Expressions;

namespace DocumentIO
{
	public class AccountFilter : DocumentIOFilter<Account>
	{
		public Guid? Id { get; set; }
		public string Login { get; set; }
		public string Role { get; set; }
		public string Email { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }

		public override IQueryable<TPaginated> Filtered<TPaginated, TOrderBy>(
			IQueryable<Account> queryable,
			Func<IQueryable<Account>, IQueryable<TPaginated>> query,
			Expression<Func<TPaginated, TOrderBy>> orderBy)
		{
			if (Id != null)
				queryable = queryable.Where(account => account.Id == Id);

			if (Login != null)
				queryable = queryable.Where(account => account.Login == Login);

			if (Role != null)
				queryable = queryable.Where(account => account.Role == Role);
			
			if (Email != null)
				queryable = queryable.Where(account => account.Email == Email);
			
			if (FirstName != null)
				queryable = queryable.Where(account => account.FirstName.Contains(FirstName));

			if (MiddleName != null)
				queryable = queryable.Where(account => account.MiddleName.Contains(MiddleName));
			
			if (LastName != null)
				queryable = queryable.Where(account => account.LastName.Contains(LastName));

			return base.Filtered(queryable, query, orderBy);
		}
	}
}