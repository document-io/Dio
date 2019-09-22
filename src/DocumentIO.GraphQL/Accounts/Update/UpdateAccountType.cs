namespace DocumentIO
{
	public class UpdateAccountType : DocumentIOInputGraphType<Account>
	{
		public UpdateAccountType()
		{
			Field(x => x.Login, nullable: true);
			Field(x => x.Email, nullable: true);
			Field(x => x.Password, nullable: true);
			Field(x => x.FirstName, nullable: true);
			Field(x => x.MiddleName, nullable: true);
			Field(x => x.LastName, nullable: true);
		}
	}
}