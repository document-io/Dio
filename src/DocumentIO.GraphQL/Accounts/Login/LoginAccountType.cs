namespace DocumentIO
{
	public class LoginAccountType : DocumentIOInputGraphType<Account>
	{
		public LoginAccountType()
		{
			Field(x => x.Email);
			Field(x => x.Password);
		}
	}
}