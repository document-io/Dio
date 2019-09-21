namespace DocumentIO
{
	public class CreateOrganizationType : DocumentIOInputGraphType<Organization>
	{
		public CreateOrganizationType()
		{
			Field(x => x.Name);
			Field<CreateAccountType, Account>("account");
		}
	}
}