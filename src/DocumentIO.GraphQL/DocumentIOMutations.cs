namespace DocumentIO
{
	public class DocumentIOMutations : DocumentIOGraphType<object>
	{
		public DocumentIOMutations()
		{
			Name = "Mutations";

			DocumentIOField<ReadOrganizationType, Organization>("createOrganization")
				.Argument<CreateOrganizationType>()
				.ResolveAsync<CreateOrganizationResolver>();

			DocumentIOField<ReadAccountType, Account>("loginAccount")
				.Argument<LoginAccountType>()
				.ResolveAsync<LoginAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("logoutAccount")
				.Authorize(Roles.User)
				.ResolveAsync<LogoutAccountResolver>();
		}
	}
}