using GraphQL.Types;

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

			DocumentIOField<ReadAccountType, Account>("createAccount")
				.Argument<CreateAccountType>()
				.Argument<NonNullGraphType<GuidGraphType>>("secret")
				.ResolveAsync<CreateAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("loginAccount")
				.Argument<LoginAccountType>()
				.ResolveAsync<LoginAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("logoutAccount")
				.Authorize(Roles.User)
				.ResolveAsync<LogoutAccountResolver>();
		}
	}
}