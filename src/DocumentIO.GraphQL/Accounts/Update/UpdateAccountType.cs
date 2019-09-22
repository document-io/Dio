namespace DocumentIO
{
	public class UpdateAccountType : DocumentIOInputGraphType<Account>
	{
		public UpdateAccountType()
		{
			NullField(x => x.Login);
			NullField(x => x.Email);
			NullField(x => x.Password);
			NullField(x => x.FirstName);
			NullField(x => x.MiddleName);
			NullField(x => x.LastName);
		}
	}
}