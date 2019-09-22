namespace DocumentIO
{
	public class AccountFilterType : DocumentIOFilterType<Account, AccountFilter>
	{
		public AccountFilterType()
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