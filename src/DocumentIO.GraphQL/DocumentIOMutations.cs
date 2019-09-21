using GraphQL.Types;

namespace DocumentIO
{
	public class DocumentIOMutations : DocumentIOGraphType<object>
	{
		public DocumentIOMutations()
		{
			Name = "Mutations";

			DocumentIOField<ReadOrganizationType, Organization>("createOrganization")
				.NonNullArgument<CreateOrganizationType>()
				.Validate<CreateOrganizationValidation>()
				.ResolveAsync<CreateOrganizationResolver>();

			DocumentIOField<ReadAccountType, Account>("createAccount")
				.NonNullArgument<GuidGraphType>("secret")
				.NonNullArgument<CreateAccountType>()
				.Validate<CreateAccountValidation>()
				.ResolveAsync<CreateAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("loginAccount")
				.Argument<LoginAccountType>()
				.Validate<LoginAccountValidation>()
				.ResolveAsync<LoginAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("logoutAccount")
				.Authorize(Roles.User)
				.ResolveAsync<LogoutAccountResolver>();

			DocumentIOField<ReadInviteType, Invite>("createInvite")
				.Authorize(Roles.Admin)
				.Argument<CreateInviteType>()
				.Validate<CreateInviteValidation>()
				.ResolveAsync<CreateInviteResolver>();

			DocumentIOField<ReadInviteType, Invite>("deleteInvite")
				.Authorize(Roles.Admin)
				.NonNullArgument<GuidGraphType>("id")
				.ResolveAsync<DeleteInviteResolver>();
		}
	}
}