namespace DocumentIO
{
	public class AccountsFilterType : DocumentIOFilterType<Account, AccountFilter>
	{
		public AccountsFilterType()
		{
			NullField(x => x.Id);
			NullField(x => x.Login);
			NullField(x => x.Role);
			NullField(x => x.Email);
			NullField(x => x.FirstName);
			NullField(x => x.MiddleName);
			NullField(x => x.LastName);
		}
	}
}