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
				.AllowUser()
				.NonNullArgument<UpdateAccountType>()
				.Validate<UpdateAccountValidation>()
				.ResolveAsync<UpdateAccountResolver>();

			DocumentIOField<ReadAccountType, Account>("logoutAccount")
				.AllowUser()
				.ResolveAsync<LogoutAccountResolver>();

			DocumentIOField<ReadInviteType, Invite>("createInvite")
				.AllowAdmin()
				.NonNullArgument<CreateInviteType>()
				.Validate<CreateInviteValidation>()
				.ResolveAsync<CreateInviteResolver>();

			DocumentIOField<ReadInviteType, Invite>("deleteInvite")
				.AllowAdmin()
				.NonNullArgument<GuidGraphType>("id")
				.Validate<DeleteInviteValidation>()
				.ResolveAsync<DeleteInviteResolver>();

			DocumentIOField<ReadBoardType, Board>("createBoard")
				.AllowUser()
				.NonNullArgument<CreateBoardType>()
				.Validate<CreateBoardValidation>()
				.ResolveAsync<CreateBoardResolver>();

			DocumentIOField<ReadBoardType, Board>("updateBoard")
				.AllowUser()
				.NonNullArgument<UpdateBoardType>()
				.Validate<UpdateBoardValidation>()
				.ResolveAsync<UpdateBoardResolver>();

			DocumentIOField<ReadColumnType, Column>("createColumn")
				.AllowUser()
				.NonNullArgument<CreateColumnType>()
				.Validate<CreateColumnValidation>()
				.ResolveAsync<CreateColumnResolver>();

			DocumentIOField<ReadColumnType, Column>("updateColumn")
				.AllowUser()
				.NonNullArgument<UpdateColumnType>()
				.Validate<UpdateColumnValidation>()
				.ResolveAsync<UpdateColumnResolver>();

			DocumentIOField<ReadColumnType, Column>("deleteColumn")
				.AllowUser()
				.NonNullArgument<DeleteColumnType>()
				.Validate<DeleteColumnValidation>()
				.ResolveAsync<DeleteColumnResolver>();

			DocumentIOField<ReadCardType, Card>("createCard")
				.AllowUser()
				.NonNullArgument<CreateCardType>()
				.Validate<CreateCardValidation>()
				.ResolveAsync<CreateCardResolver>();

			DocumentIOField<ReadCardType, Card>("updateCard")
				.AllowUser()
				.NonNullArgument<UpdateCardType>()
				.Validate<UpdateCardValidation>()
				.ResolveAsync<UpdateCardResolver>();

			DocumentIOField<ReadCardType, Card>("deleteCard")
				.AllowUser()
				.NonNullArgument<DeleteCardType>()
				.Validate<DeleteCardValidation>()
				.ResolveAsync<DeleteCardResolver>();

			DocumentIOField<ReadCommentType, CardComment>("createComment")
				.AllowUser()
				.NonNullArgument<CreateCommentType>()
				.Validate<CreateCommentValidation>()
				.ResolveAsync<CreateCommentResolver>();

			DocumentIOField<ReadCommentType, CardComment>("updateComment")
				.AllowUser()
				.NonNullArgument<UpdateCommentType>()
				.Validate<UpdateCommentValidation>()
				.ResolveAsync<UpdateCommentResolver>();

			DocumentIOField<ReadCommentType, CardComment>("deleteComment")
				.AllowUser()
				.NonNullArgument<GuidGraphType>("id")
				.Validate<DeleteCommentValidation>()
				.ResolveAsync<DeleteCommentResolver>();

			DocumentIOField<ReadCardType, Card>("createAssignment")
				.AllowUser()
				.NonNullArgument<CreateAssignmentType>()
				.Validate<CreateAssignmentValidation>()
				.ResolveAsync<CreateAssignmentResolver>();

			DocumentIOField<ReadCardType, Card>("deteleAssignment")
				.AllowUser()
				.NonNullArgument<DeleteAssignmentType>()
				.Validate<DeleteAssignmentValidation>()
				.ResolveAsync<DeleteAssignmentResolver>();

			DocumentIOField<ReadAttachmentType, CardAttachment>("createAttachment")
				.AllowUser()
				.NonNullArgument<CreateCardAttachmentType>()
				.ResolveAsync<CreateCardAttachmentResolver>();

			DocumentIOField<ReadAttachmentType, CardAttachment>("updateAttachment")
				.AllowUser()
				.NonNullArgument<UpdateAttachmentType>()
				.ResolveAsync<UpdateCardAttachmentResolver>();

			DocumentIOField<ReadAttachmentType, CardAttachment>("deleteAttachment")
				.AllowUser()
				.NonNullArgument<DeleteCardAttachmentType>()
				.ResolveAsync<DeleteCardAttachmentResolver>();

			DocumentIOField<ReadLabelType, Label>("createLabel")
				.AllowUser()
				.NonNullArgument<CreateLabelType>()
				.Validate<CreateLabelValidation>()
				.ResolveAsync<CreateLabelResolver>();

			DocumentIOField<ReadLabelType, Label>("updateLabel")
				.AllowUser()
				.NonNullArgument<UpdateLabelType>()
				.Validate<UpdateLabelValidation>()
				.ResolveAsync<UpdateLabelResolver>();

			DocumentIOField<ReadCardType, Card>("createCardLabel")
				.AllowUser()
				.NonNullArgument<CreateCardLabelType>()
				.Validate<CreateCardLabelValidation>()
				.ResolveAsync<CreateCardLabelResolver>();

			DocumentIOField<ReadCardType, Card>("deleteCardLabel")
				.AllowUser()
				.NonNullArgument<DeleteCardLabelType>()
				.Validate<DeleteCardLabelValidation>()
				.ResolveAsync<DeleteCardLabelResolver>();
		}
	}
}