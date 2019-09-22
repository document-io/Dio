namespace DocumentIO
{
	public class CreateAccountType : DocumentIOInputGraphType<Account>
	{
		public CreateAccountType()
		{
			Field(x => x.Login);
			Field(x => x.Email);
			Field(x => x.Password);
			Field(x => x.FirstName);
			NullField(x => x.MiddleName);
			Field(x => x.LastName);
		}
	}
}