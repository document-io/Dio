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
				.NonNullArgument<LoginAccountType>()
				.Validate<LoginAccountValidation>()
				.ResolveAsync<LoginAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("updateAccount")
				.Authorize(Roles.User)
				.NonNullArgument<UpdateAccountType>()
				.Validate<UpdateAccountValidation>()
				.ResolveAsync<UpdateAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("logoutAccount")
				.Authorize(Roles.User)
				.ResolveAsync<LogoutAccountResolver>();

			DocumentIOField<ReadInviteType, Invite>("createInvite")
				.Authorize(Roles.Admin)
				.NonNullArgument<CreateInviteType>()
				.Validate<CreateInviteValidation>()
				.ResolveAsync<CreateInviteResolver>();

			DocumentIOField<ReadInviteType, Invite>("deleteInvite")
				.Authorize(Roles.Admin)
				.NonNullArgument<GuidGraphType>("id")
				.Validate<DeleteInviteValidation>()
				.ResolveAsync<DeleteInviteResolver>();

			DocumentIOField<ReadBoardType, Board>("createBoard")
				.Authorize(Roles.User)
				.NonNullArgument<CreateBoardType>()
				.Validate<CreateBoardValidation>()
				.ResolveAsync<CreateBoardResolver>();

			DocumentIOField<ReadBoardType, Board>("updateBoard")
				.Authorize(Roles.User)
				.NonNullArgument<UpdateBoardType>()
				.Validate<UpdateBoardValidation>()
				.ResolveAsync<UpdateBoardResolver>();

			DocumentIOField<ReadColumnType, Column>("createColumn")
				.Authorize(Roles.User)
				.NonNullArgument<CreateColumnType>()
				.Validate<CreateColumnValidation>()
				.ResolveAsync<CreateColumnResolver>();

			DocumentIOField<ReadColumnType, Column>("updateColumn")
				.Authorize(Roles.User)
				.NonNullArgument<UpdateColumnType>()
				.Validate<UpdateColumnValidation>()
				.ResolveAsync<UpdateColumnResolver>();

			DocumentIOField<ReadCardType, Card>("createCard")
				.Authorize(Roles.User)
				.NonNullArgument<CreateCardType>()
				.Validate<CreateCardValidation>()
				.ResolveAsync<CreateCardResolver>();

			DocumentIOField<ReadCardType, Card>("updateCard")
				.Authorize(Roles.User)
				.NonNullArgument<UpdateCardType>()
				.Validate<UpdateCardValidation>()
				.ResolveAsync<UpdateCardResolver>();

			DocumentIOField<ReadCommentType, CardComment>("createComment")
				.Authorize(Roles.User)
				.NonNullArgument<CreateCommentType>()
				.Validate<CreateCommentValidation>()
				.ResolveAsync<CreateCommentResolver>();

			DocumentIOField<ReadCommentType, CardComment>("updateComment")
				.Authorize(Roles.User)
				.NonNullArgument<UpdateCommentType>()
				.Validate<UpdateCommentValidation>()
				.ResolveAsync<UpdateCommentResolver>();

			DocumentIOField<ReadCommentType, CardComment>("deleteComment")
				.Authorize(Roles.User)
				.NonNullArgument<GuidGraphType>("id")
				.Validate<DeleteCommentValidation>()
				.ResolveAsync<DeleteCommentResolver>();

			DocumentIOField<ReadCardType, Card>("createAssignment")
				.Authorize(Roles.User)
				.NonNullArgument<CreateAssignmentType>()
				.Validate<CreateAssignmentValidation>()
				.ResolveAsync<CreateAssignmentResolver>();

			DocumentIOField<ReadCardType, Card>("deteleAssignment")
				.Authorize(Roles.User)
				.NonNullArgument<DeleteAssignmentType>()
				.Validate<DeleteAssignmentValidation>()
				.ResolveAsync<DeleteAssignmentResolver>();

			DocumentIOField<ReadLabelType, Label>("createLabel")
				.Authorize(Roles.User)
				.NonNullArgument<CreateLabelType>()
				.Validate<CreateLabelValidation>()
				.ResolveAsync<CreateLabelResolver>();

			DocumentIOField<ReadLabelType, Label>("updateLabel")
				.Authorize(Roles.User)
				.NonNullArgument<UpdateLabelType>()
				.Validate<UpdateLabelValidation>()
				.ResolveAsync<UpdateLabelResolver>();

			DocumentIOField<ReadCardType, Card>("createCardLabel")
				.Authorize(Roles.User)
				.NonNullArgument<CreateCardLabelType>()
				.Validate<CreateCardLabelValidation>()
				.ResolveAsync<CreateCardLabelResolver>();

			DocumentIOField<ReadCardType, Card>("deleteCardLabel")
				.Authorize(Roles.User)
				.NonNullArgument<DeleteCardLabelType>()
				.Validate<DeleteCardLabelValidation>()
				.ResolveAsync<DeleteCardLabelResolver>();
		}
	}
}