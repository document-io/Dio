using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DocumentIO
{
	public class UpdateAccountModel
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string FirstName { get; set; }
		public string MiddleName { get; set; }
		public string LastName { get; set; }

		public async Task<Account> Update(DatabaseContext databaseContext, int accountId)
		{
			var account = await databaseContext.Accounts.SingleAsync(x => x.Id == accountId);

			if (Email != null)
				account.Email = Email;

			if (Password != null)
				account.Password = Password;

			if (FirstName != null)
				account.FirstName = FirstName;

			if (MiddleName != null)
				account.MiddleName = MiddleName;

			if (LastName != null)
				account.LastName = LastName;

			return account;
		}
	}
}