import gql from 'graphql-tag';
import * as ApolloReactCommon from '@apollo/react-common';
import * as ApolloReactHooks from '@apollo/react-hooks';
export type Maybe<T> = T | null;
/** All built-in and custom scalars, mapped to their actual values */
export type Scalars = {
  ID: string,
  String: string,
  Boolean: boolean,
  Int: number,
  Float: number,
  Guid: any,
  /** 
 * The `DateTimeOffset` scalar type represents a date, time and offset from UTC.
   * `DateTimeOffset` expects timestamps to be formatted in accordance with the
   * [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
 */
  DateTimeOffset: any,
  /** 
 * The `Date` scalar type represents a year, month and day in accordance with the
   * [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
 */
  Date: any,
  Byte: any,
  /** 
 * The `DateTime` scalar type represents a date and time. `DateTime` expects
   * timestamps to be formatted in accordance with the
   * [ISO-8601](https://en.wikipedia.org/wiki/ISO_8601) standard.
 */
  DateTime: any,
  Decimal: any,
  /** The `Milliseconds` scalar type represents a period of time represented as the total number of milliseconds. */
  Milliseconds: any,
  SByte: any,
  /** The `Seconds` scalar type represents a period of time represented as the total number of seconds. */
  Seconds: any,
  Short: any,
  UInt: any,
  ULong: any,
  Uri: any,
  UShort: any,
};


export type CreateAccountType = {
  login: Scalars['String'],
  email: Scalars['String'],
  password: Scalars['String'],
  firstName: Scalars['String'],
  middleName?: Maybe<Scalars['String']>,
  lastName: Scalars['String'],
};

export type CreateAssignmentType = {
  cardId: Scalars['ID'],
  accountId: Scalars['ID'],
};

export type CreateBoardType = {
  name: Scalars['String'],
};

export type CreateCardAttachmentType = {
  name: Scalars['String'],
  cardId: Scalars['ID'],
};

export type CreateCardLabelType = {
  cardId: Scalars['ID'],
  labelId: Scalars['ID'],
};

export type CreateCardType = {
  name: Scalars['String'],
  description: Scalars['String'],
  columnId: Scalars['ID'],
};

export type CreateColumnType = {
  name: Scalars['String'],
  boardId: Scalars['ID'],
};

export type CreateCommentType = {
  text: Scalars['String'],
  cardId: Scalars['ID'],
};

export type CreateInviteType = {
  role: Scalars['String'],
  description: Scalars['String'],
  dueDate?: Maybe<Scalars['DateTimeOffset']>,
};

export type CreateLabelType = {
  name: Scalars['String'],
  description: Scalars['String'],
  color: Scalars['String'],
  boardId: Scalars['ID'],
};

export type CreateOrganizationType = {
  name: Scalars['String'],
  accounts: Array<Maybe<CreateAccountType>>,
};





export type DeleteAssignmentType = {
  cardId: Scalars['ID'],
  accountId: Scalars['ID'],
};

export type DeleteCardAttachmentType = {
  id: Scalars['ID'],
};

export type DeleteCardLabelType = {
  cardId: Scalars['ID'],
  labelId: Scalars['ID'],
};

export type DeleteCardType = {
  id: Scalars['ID'],
};

export type DeleteColumnType = {
  id: Scalars['ID'],
};

export enum DocumentIoOrderBy {
  Ascending = 'ASCENDING',
  Descending = 'DESCENDING'
}


export type LoginAccountType = {
  email: Scalars['String'],
  password: Scalars['String'],
};


export type Mutations = {
   __typename?: 'Mutations',
  createAccount?: Maybe<ReadAccountType>,
  createAssignment?: Maybe<ReadCardType>,
  createAttachment?: Maybe<ReadAttachmentType>,
  createBoard?: Maybe<ReadBoardType>,
  createCard?: Maybe<ReadCardType>,
  createCardLabel?: Maybe<ReadCardType>,
  createColumn?: Maybe<ReadColumnType>,
  createComment?: Maybe<ReadCommentType>,
  createInvite?: Maybe<ReadInviteType>,
  createLabel?: Maybe<ReadLabelType>,
  createOrganization?: Maybe<ReadOrganizationType>,
  deleteAttachment?: Maybe<ReadAttachmentType>,
  deleteCard?: Maybe<ReadCardType>,
  deleteCardLabel?: Maybe<ReadCardType>,
  deleteColumn?: Maybe<ReadColumnType>,
  deleteComment?: Maybe<ReadCommentType>,
  deleteInvite?: Maybe<ReadInviteType>,
  deteleAssignment?: Maybe<ReadCardType>,
  loginAccount?: Maybe<ReadAccountType>,
  logoutAccount?: Maybe<ReadAccountType>,
  updateAccount?: Maybe<ReadAccountType>,
  updateAttachment?: Maybe<ReadAttachmentType>,
  updateBoard?: Maybe<ReadBoardType>,
  updateCard?: Maybe<ReadCardType>,
  updateColumn?: Maybe<ReadColumnType>,
  updateComment?: Maybe<ReadCommentType>,
  updateLabel?: Maybe<ReadLabelType>,
};


export type MutationsCreateAccountArgs = {
  secret: Scalars['Guid'],
  input: CreateAccountType
};


export type MutationsCreateAssignmentArgs = {
  input: CreateAssignmentType
};


export type MutationsCreateAttachmentArgs = {
  input: CreateCardAttachmentType
};


export type MutationsCreateBoardArgs = {
  input: CreateBoardType
};


export type MutationsCreateCardArgs = {
  input: CreateCardType
};


export type MutationsCreateCardLabelArgs = {
  input: CreateCardLabelType
};


export type MutationsCreateColumnArgs = {
  input: CreateColumnType
};


export type MutationsCreateCommentArgs = {
  input: CreateCommentType
};


export type MutationsCreateInviteArgs = {
  input: CreateInviteType
};


export type MutationsCreateLabelArgs = {
  input: CreateLabelType
};


export type MutationsCreateOrganizationArgs = {
  input: CreateOrganizationType
};


export type MutationsDeleteAttachmentArgs = {
  input: DeleteCardAttachmentType
};


export type MutationsDeleteCardArgs = {
  input: DeleteCardType
};


export type MutationsDeleteCardLabelArgs = {
  input: DeleteCardLabelType
};


export type MutationsDeleteColumnArgs = {
  input: DeleteColumnType
};


export type MutationsDeleteCommentArgs = {
  id: Scalars['Guid']
};


export type MutationsDeleteInviteArgs = {
  id: Scalars['Guid']
};


export type MutationsDeteleAssignmentArgs = {
  input: DeleteAssignmentType
};


export type MutationsLoginAccountArgs = {
  input: LoginAccountType
};


export type MutationsUpdateAccountArgs = {
  input: UpdateAccountType
};


export type MutationsUpdateAttachmentArgs = {
  input: UpdateAttachmentType
};


export type MutationsUpdateBoardArgs = {
  input: UpdateBoardType
};


export type MutationsUpdateCardArgs = {
  input: UpdateCardType
};


export type MutationsUpdateColumnArgs = {
  input: UpdateColumnType
};


export type MutationsUpdateCommentArgs = {
  input: UpdateCommentType
};


export type MutationsUpdateLabelArgs = {
  input: UpdateLabelType
};

export type Queries = {
   __typename?: 'Queries',
  accountId?: Maybe<Scalars['Guid']>,
  accounts?: Maybe<Array<Maybe<ReadAccountType>>>,
  attachments?: Maybe<Array<Maybe<ReadAttachmentType>>>,
  boards?: Maybe<Array<Maybe<ReadBoardType>>>,
  cards?: Maybe<Array<Maybe<ReadCardType>>>,
  columns?: Maybe<Array<Maybe<ReadColumnType>>>,
  comments?: Maybe<Array<Maybe<ReadCommentType>>>,
  count?: Maybe<ReadCountType>,
  events?: Maybe<Array<Maybe<ReadEventType>>>,
  invites?: Maybe<Array<Maybe<ReadInviteType>>>,
  labels?: Maybe<Array<Maybe<ReadLabelType>>>,
  organization: ReadOrganizationType,
  search?: Maybe<Array<Maybe<SearchInterface>>>,
  version: Scalars['String'],
};


export type QueriesAccountsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  login?: Maybe<Scalars['String']>,
  role?: Maybe<Scalars['String']>,
  email?: Maybe<Scalars['String']>,
  firstName?: Maybe<Scalars['String']>,
  middleName?: Maybe<Scalars['String']>,
  lastName?: Maybe<Scalars['String']>
};


export type QueriesAttachmentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  fileName?: Maybe<Scalars['String']>,
  contentType?: Maybe<Scalars['String']>,
  contentDisposition?: Maybe<Scalars['String']>,
  length?: Maybe<Scalars['Int']>,
  cardId?: Maybe<Scalars['ID']>
};


export type QueriesBoardsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>
};


export type QueriesCardsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>,
  dueDate?: Maybe<Scalars['DateTimeOffset']>
};


export type QueriesColumnsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>
};


export type QueriesCommentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>,
  createdAt?: Maybe<Scalars['DateTimeOffset']>,
  updatedAt?: Maybe<Scalars['DateTimeOffset']>
};


export type QueriesEventsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>
};


export type QueriesInvitesArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  role?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>
};


export type QueriesLabelsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>,
  color?: Maybe<Scalars['String']>
};


export type QueriesSearchArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  name?: Maybe<Scalars['String']>,
  createdAt?: Maybe<Scalars['Date']>
};

export type ReadAccountType = {
   __typename?: 'ReadAccountType',
  assignments?: Maybe<Array<Maybe<ReadCardType>>>,
  attachments?: Maybe<Array<Maybe<ReadAttachmentType>>>,
  comments?: Maybe<Array<Maybe<ReadCommentType>>>,
  createdAt: Scalars['DateTimeOffset'],
  email: Scalars['String'],
  events?: Maybe<Array<Maybe<ReadEventType>>>,
  firstName: Scalars['String'],
  id: Scalars['ID'],
  invite: ReadInviteType,
  lastName: Scalars['String'],
  login: Scalars['String'],
  middleName?: Maybe<Scalars['String']>,
  organization: ReadOrganizationType,
  role: Scalars['String'],
};


export type ReadAccountTypeAssignmentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>,
  dueDate?: Maybe<Scalars['DateTimeOffset']>
};


export type ReadAccountTypeAttachmentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  fileName?: Maybe<Scalars['String']>,
  contentType?: Maybe<Scalars['String']>,
  contentDisposition?: Maybe<Scalars['String']>,
  length?: Maybe<Scalars['Int']>,
  cardId?: Maybe<Scalars['ID']>
};


export type ReadAccountTypeCommentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>,
  createdAt?: Maybe<Scalars['DateTimeOffset']>,
  updatedAt?: Maybe<Scalars['DateTimeOffset']>
};


export type ReadAccountTypeEventsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>
};

export type ReadAttachmentType = {
   __typename?: 'ReadAttachmentType',
  account: ReadAccountType,
  card: ReadCardType,
  contentDisposition?: Maybe<Scalars['String']>,
  contentType?: Maybe<Scalars['String']>,
  createdAt: Scalars['DateTimeOffset'],
  fileName?: Maybe<Scalars['String']>,
  id: Scalars['ID'],
  length?: Maybe<Scalars['Int']>,
  name: Scalars['String'],
};

export type ReadBoardType = SearchInterface & {
   __typename?: 'ReadBoardType',
  columns?: Maybe<Array<Maybe<ReadColumnType>>>,
  createdAt: Scalars['DateTimeOffset'],
  id: Scalars['ID'],
  labels?: Maybe<Array<Maybe<ReadLabelType>>>,
  name: Scalars['String'],
  organization: ReadOrganizationType,
};


export type ReadBoardTypeColumnsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>
};


export type ReadBoardTypeLabelsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>,
  color?: Maybe<Scalars['String']>
};

export type ReadCardType = SearchInterface & {
   __typename?: 'ReadCardType',
  assignments?: Maybe<Array<Maybe<ReadAccountType>>>,
  attachments?: Maybe<Array<Maybe<ReadAttachmentType>>>,
  column: ReadColumnType,
  comments?: Maybe<Array<Maybe<ReadCommentType>>>,
  content?: Maybe<Scalars['String']>,
  createdAt: Scalars['DateTimeOffset'],
  description?: Maybe<Scalars['String']>,
  dueDate?: Maybe<Scalars['DateTimeOffset']>,
  events?: Maybe<Array<Maybe<ReadEventType>>>,
  id: Scalars['ID'],
  labels?: Maybe<Array<Maybe<ReadLabelType>>>,
  name: Scalars['String'],
  order: Scalars['Int'],
  updatedAt?: Maybe<Scalars['DateTimeOffset']>,
};


export type ReadCardTypeAssignmentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  login?: Maybe<Scalars['String']>,
  role?: Maybe<Scalars['String']>,
  email?: Maybe<Scalars['String']>,
  firstName?: Maybe<Scalars['String']>,
  middleName?: Maybe<Scalars['String']>,
  lastName?: Maybe<Scalars['String']>
};


export type ReadCardTypeAttachmentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  fileName?: Maybe<Scalars['String']>,
  contentType?: Maybe<Scalars['String']>,
  contentDisposition?: Maybe<Scalars['String']>,
  length?: Maybe<Scalars['Int']>,
  cardId?: Maybe<Scalars['ID']>
};


export type ReadCardTypeCommentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>,
  createdAt?: Maybe<Scalars['DateTimeOffset']>,
  updatedAt?: Maybe<Scalars['DateTimeOffset']>
};


export type ReadCardTypeEventsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>
};


export type ReadCardTypeLabelsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>,
  color?: Maybe<Scalars['String']>
};

export type ReadColumnType = SearchInterface & {
   __typename?: 'ReadColumnType',
  board: ReadBoardType,
  cards?: Maybe<Array<Maybe<ReadCardType>>>,
  createdAt: Scalars['DateTimeOffset'],
  id: Scalars['ID'],
  name: Scalars['String'],
  order: Scalars['Int'],
};


export type ReadColumnTypeCardsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>,
  dueDate?: Maybe<Scalars['DateTimeOffset']>
};

export type ReadCommentType = {
   __typename?: 'ReadCommentType',
  account: ReadAccountType,
  card: ReadCardType,
  createdAt: Scalars['DateTimeOffset'],
  id: Scalars['ID'],
  text: Scalars['String'],
  updatedAt?: Maybe<Scalars['DateTimeOffset']>,
};

export type ReadCountType = {
   __typename?: 'ReadCountType',
  accounts?: Maybe<Scalars['Int']>,
  attachments?: Maybe<Scalars['Int']>,
  boards?: Maybe<Scalars['Int']>,
  cards?: Maybe<Scalars['Int']>,
  columns?: Maybe<Scalars['Int']>,
  comments?: Maybe<Scalars['Int']>,
  events?: Maybe<Scalars['Int']>,
  invites?: Maybe<Scalars['Int']>,
  labels?: Maybe<Scalars['Int']>,
};


export type ReadCountTypeAccountsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  login?: Maybe<Scalars['String']>,
  role?: Maybe<Scalars['String']>,
  email?: Maybe<Scalars['String']>,
  firstName?: Maybe<Scalars['String']>,
  middleName?: Maybe<Scalars['String']>,
  lastName?: Maybe<Scalars['String']>
};


export type ReadCountTypeAttachmentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  fileName?: Maybe<Scalars['String']>,
  contentType?: Maybe<Scalars['String']>,
  contentDisposition?: Maybe<Scalars['String']>,
  length?: Maybe<Scalars['Int']>,
  cardId?: Maybe<Scalars['ID']>
};


export type ReadCountTypeBoardsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>
};


export type ReadCountTypeCardsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>,
  dueDate?: Maybe<Scalars['DateTimeOffset']>
};


export type ReadCountTypeColumnsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>
};


export type ReadCountTypeCommentsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>,
  createdAt?: Maybe<Scalars['DateTimeOffset']>,
  updatedAt?: Maybe<Scalars['DateTimeOffset']>
};


export type ReadCountTypeEventsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  content?: Maybe<Scalars['String']>
};


export type ReadCountTypeInvitesArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  role?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>
};


export type ReadCountTypeLabelsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>,
  color?: Maybe<Scalars['String']>
};

export type ReadEventType = {
   __typename?: 'ReadEventType',
  account: ReadAccountType,
  card: ReadCardType,
  content: Scalars['String'],
  id: Scalars['ID'],
};

export type ReadInviteType = {
   __typename?: 'ReadInviteType',
  account?: Maybe<ReadAccountType>,
  createdAt: Scalars['DateTimeOffset'],
  description: Scalars['String'],
  dueDate?: Maybe<Scalars['DateTimeOffset']>,
  id: Scalars['ID'],
  organization: ReadOrganizationType,
  role: Scalars['String'],
  secret: Scalars['ID'],
};

export type ReadLabelType = {
   __typename?: 'ReadLabelType',
  board: ReadBoardType,
  cards?: Maybe<Array<Maybe<ReadCardType>>>,
  color: Scalars['String'],
  description: Scalars['String'],
  id: Scalars['ID'],
  name: Scalars['String'],
};

export type ReadOrganizationType = {
   __typename?: 'ReadOrganizationType',
  accounts?: Maybe<Array<Maybe<ReadAccountType>>>,
  boards?: Maybe<Array<Maybe<ReadBoardType>>>,
  id: Scalars['ID'],
  invites?: Maybe<Array<Maybe<ReadInviteType>>>,
  name: Scalars['String'],
};


export type ReadOrganizationTypeAccountsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  login?: Maybe<Scalars['String']>,
  role?: Maybe<Scalars['String']>,
  email?: Maybe<Scalars['String']>,
  firstName?: Maybe<Scalars['String']>,
  middleName?: Maybe<Scalars['String']>,
  lastName?: Maybe<Scalars['String']>
};


export type ReadOrganizationTypeBoardsArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>
};


export type ReadOrganizationTypeInvitesArgs = {
  page?: Maybe<Scalars['Int']>,
  size?: Maybe<Scalars['Int']>,
  orderBy?: Maybe<DocumentIoOrderBy>,
  id?: Maybe<Scalars['ID']>,
  role?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>
};


export type SearchInterface = {
  name?: Maybe<Scalars['String']>,
};





export type UpdateAccountType = {
  login?: Maybe<Scalars['String']>,
  email?: Maybe<Scalars['String']>,
  password?: Maybe<Scalars['String']>,
  firstName?: Maybe<Scalars['String']>,
  middleName?: Maybe<Scalars['String']>,
  lastName?: Maybe<Scalars['String']>,
};

export type UpdateAttachmentType = {
  id: Scalars['ID'],
  name: Scalars['String'],
};

export type UpdateBoardType = {
  id: Scalars['ID'],
  name: Scalars['String'],
};

export type UpdateCardType = {
  id: Scalars['ID'],
  columnId?: Maybe<Scalars['ID']>,
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>,
  dueDate?: Maybe<Scalars['DateTimeOffset']>,
  content?: Maybe<Scalars['String']>,
};

export type UpdateColumnType = {
  id: Scalars['ID'],
  name?: Maybe<Scalars['String']>,
  order?: Maybe<Scalars['Int']>,
};

export type UpdateCommentType = {
  id: Scalars['ID'],
  text: Scalars['String'],
};

export type UpdateLabelType = {
  id: Scalars['ID'],
  name?: Maybe<Scalars['String']>,
  description?: Maybe<Scalars['String']>,
  color?: Maybe<Scalars['String']>,
};



export type LogoutAccountMutationVariables = {};


export type LogoutAccountMutation = (
  { __typename?: 'Mutations' }
  & { logoutAccount: Maybe<(
    { __typename?: 'ReadAccountType' }
    & Pick<ReadAccountType, 'id'>
  )> }
);

export type ReadCardQueryVariables = {
  cardId?: Maybe<Scalars['ID']>
};


export type ReadCardQuery = (
  { __typename?: 'Queries' }
  & { cards: Maybe<Array<Maybe<(
    { __typename?: 'ReadCardType' }
    & Pick<ReadCardType, 'name' | 'content' | 'description' | 'dueDate' | 'createdAt'>
    & { assignments: Maybe<Array<Maybe<(
      { __typename?: 'ReadAccountType' }
      & Pick<ReadAccountType, 'firstName' | 'lastName'>
    )>>>, comments: Maybe<Array<Maybe<(
      { __typename?: 'ReadCommentType' }
      & Pick<ReadCommentType, 'id' | 'text'>
      & { account: (
        { __typename?: 'ReadAccountType' }
        & Pick<ReadAccountType, 'firstName' | 'lastName'>
      ) }
    )>>> }
  )>>> }
);

export type CreateColumnMutationVariables = {
  column: CreateColumnType
};


export type CreateColumnMutation = (
  { __typename?: 'Mutations' }
  & { createColumn: Maybe<(
    { __typename?: 'ReadColumnType' }
    & Pick<ReadColumnType, 'id'>
  )> }
);

export type CreateCardMutationVariables = {
  card: CreateCardType
};


export type CreateCardMutation = (
  { __typename?: 'Mutations' }
  & { createCard: Maybe<(
    { __typename?: 'ReadCardType' }
    & Pick<ReadCardType, 'id'>
  )> }
);

export type DeleteCardMutationVariables = {
  card: DeleteCardType
};


export type DeleteCardMutation = (
  { __typename?: 'Mutations' }
  & { deleteCard: Maybe<(
    { __typename?: 'ReadCardType' }
    & Pick<ReadCardType, 'id'>
  )> }
);

export type DeleteColumnMutationVariables = {
  column: DeleteColumnType
};


export type DeleteColumnMutation = (
  { __typename?: 'Mutations' }
  & { deleteColumn: Maybe<(
    { __typename?: 'ReadColumnType' }
    & Pick<ReadColumnType, 'id'>
  )> }
);

export type UpdateCardMutationVariables = {
  card: UpdateCardType
};


export type UpdateCardMutation = (
  { __typename?: 'Mutations' }
  & { updateCard: Maybe<(
    { __typename?: 'ReadCardType' }
    & Pick<ReadCardType, 'content'>
  )> }
);

export type ReadColumnsQueryVariables = {
  boardId?: Maybe<Scalars['ID']>
};


export type ReadColumnsQuery = (
  { __typename?: 'Queries' }
  & { boards: Maybe<Array<Maybe<(
    { __typename?: 'ReadBoardType' }
    & { columns: Maybe<Array<Maybe<(
      { __typename?: 'ReadColumnType' }
      & Pick<ReadColumnType, 'id' | 'name'>
      & { cards: Maybe<Array<Maybe<(
        { __typename?: 'ReadCardType' }
        & Pick<ReadCardType, 'id' | 'name' | 'description'>
      )>>> }
    )>>> }
  )>>> }
);

export type CreateOrganizationMutationVariables = {
  organization: CreateOrganizationType
};


export type CreateOrganizationMutation = (
  { __typename?: 'Mutations' }
  & { createOrganization: Maybe<(
    { __typename?: 'ReadOrganizationType' }
    & Pick<ReadOrganizationType, 'id'>
  )> }
);

export type CreateBoardMutationVariables = {
  board: CreateBoardType
};


export type CreateBoardMutation = (
  { __typename?: 'Mutations' }
  & { createBoard: Maybe<(
    { __typename?: 'ReadBoardType' }
    & Pick<ReadBoardType, 'id'>
  )> }
);

export type ReadBoardsQueryVariables = {};


export type ReadBoardsQuery = (
  { __typename?: 'Queries' }
  & { boards: Maybe<Array<Maybe<(
    { __typename?: 'ReadBoardType' }
    & Pick<ReadBoardType, 'id' | 'name'>
  )>>> }
);

export type DeleteInviteMutationVariables = {
  inviteId: Scalars['Guid']
};


export type DeleteInviteMutation = (
  { __typename?: 'Mutations' }
  & { deleteInvite: Maybe<(
    { __typename?: 'ReadInviteType' }
    & Pick<ReadInviteType, 'id'>
  )> }
);

export type CreateInviteMutationVariables = {
  invite: CreateInviteType
};


export type CreateInviteMutation = (
  { __typename?: 'Mutations' }
  & { createInvite: Maybe<(
    { __typename?: 'ReadInviteType' }
    & Pick<ReadInviteType, 'id'>
  )> }
);

export type ReadInvitesQueryVariables = {};


export type ReadInvitesQuery = (
  { __typename?: 'Queries' }
  & { invites: Maybe<Array<Maybe<(
    { __typename?: 'ReadInviteType' }
    & Pick<ReadInviteType, 'id' | 'role' | 'dueDate' | 'description' | 'secret'>
    & { account: Maybe<(
      { __typename?: 'ReadAccountType' }
      & Pick<ReadAccountType, 'id' | 'firstName' | 'lastName'>
    )> }
  )>>> }
);

export type ReadAccountsQueryVariables = {};


export type ReadAccountsQuery = (
  { __typename?: 'Queries' }
  & { accounts: Maybe<Array<Maybe<(
    { __typename?: 'ReadAccountType' }
    & Pick<ReadAccountType, 'id' | 'email' | 'login' | 'role' | 'firstName' | 'lastName' | 'middleName'>
  )>>> }
);

export type LoginAccountMutationVariables = {
  account: LoginAccountType
};


export type LoginAccountMutation = (
  { __typename?: 'Mutations' }
  & { loginAccount: Maybe<(
    { __typename?: 'ReadAccountType' }
    & Pick<ReadAccountType, 'id'>
  )> }
);

export type ReadProfileQueryVariables = {
  accountID?: Maybe<Scalars['ID']>
};


export type ReadProfileQuery = (
  { __typename?: 'Queries' }
  & { accounts: Maybe<Array<Maybe<(
    { __typename?: 'ReadAccountType' }
    & Pick<ReadAccountType, 'id' | 'login' | 'email' | 'role' | 'firstName' | 'lastName' | 'middleName'>
    & { organization: (
      { __typename?: 'ReadOrganizationType' }
      & Pick<ReadOrganizationType, 'id' | 'name'>
    ), assignments: Maybe<Array<Maybe<(
      { __typename?: 'ReadCardType' }
      & { column: (
        { __typename?: 'ReadColumnType' }
        & { cards: Maybe<Array<Maybe<(
          { __typename?: 'ReadCardType' }
          & Pick<ReadCardType, 'id' | 'name' | 'dueDate'>
        )>>> }
      ) }
    )>>> }
  )>>> }
);

export type CreateAccountMutationVariables = {
  secret: Scalars['Guid'],
  account: CreateAccountType
};


export type CreateAccountMutation = (
  { __typename?: 'Mutations' }
  & { createAccount: Maybe<(
    { __typename?: 'ReadAccountType' }
    & Pick<ReadAccountType, 'id'>
  )> }
);


export const LogoutAccountDocument = gql`
    mutation LogoutAccount {
  logoutAccount {
    id
  }
}
    `;
export type LogoutAccountMutationFn = ApolloReactCommon.MutationFunction<LogoutAccountMutation, LogoutAccountMutationVariables>;

/**
 * __useLogoutAccountMutation__
 *
 * To run a mutation, you first call `useLogoutAccountMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useLogoutAccountMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [logoutAccountMutation, { data, loading, error }] = useLogoutAccountMutation({
 *   variables: {
 *   },
 * });
 */
export function useLogoutAccountMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<LogoutAccountMutation, LogoutAccountMutationVariables>) {
        return ApolloReactHooks.useMutation<LogoutAccountMutation, LogoutAccountMutationVariables>(LogoutAccountDocument, baseOptions);
      }
export type LogoutAccountMutationHookResult = ReturnType<typeof useLogoutAccountMutation>;
export type LogoutAccountMutationResult = ApolloReactCommon.MutationResult<LogoutAccountMutation>;
export type LogoutAccountMutationOptions = ApolloReactCommon.BaseMutationOptions<LogoutAccountMutation, LogoutAccountMutationVariables>;
export const ReadCardDocument = gql`
    query ReadCard($cardId: ID) {
  cards(id: $cardId) {
    name
    content
    description
    dueDate
    createdAt
    assignments {
      firstName
      lastName
    }
    comments {
      id
      text
      account {
        firstName
        lastName
      }
    }
  }
}
    `;

/**
 * __useReadCardQuery__
 *
 * To run a query within a React component, call `useReadCardQuery` and pass it any options that fit your needs.
 * When your component renders, `useReadCardQuery` returns an object from Apollo Client that contains loading, error, and data properties 
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useReadCardQuery({
 *   variables: {
 *      cardId: // value for 'cardId'
 *   },
 * });
 */
export function useReadCardQuery(baseOptions?: ApolloReactHooks.QueryHookOptions<ReadCardQuery, ReadCardQueryVariables>) {
        return ApolloReactHooks.useQuery<ReadCardQuery, ReadCardQueryVariables>(ReadCardDocument, baseOptions);
      }
export function useReadCardLazyQuery(baseOptions?: ApolloReactHooks.LazyQueryHookOptions<ReadCardQuery, ReadCardQueryVariables>) {
          return ApolloReactHooks.useLazyQuery<ReadCardQuery, ReadCardQueryVariables>(ReadCardDocument, baseOptions);
        }
export type ReadCardQueryHookResult = ReturnType<typeof useReadCardQuery>;
export type ReadCardLazyQueryHookResult = ReturnType<typeof useReadCardLazyQuery>;
export type ReadCardQueryResult = ApolloReactCommon.QueryResult<ReadCardQuery, ReadCardQueryVariables>;
export const CreateColumnDocument = gql`
    mutation CreateColumn($column: CreateColumnType!) {
  createColumn(input: $column) {
    id
  }
}
    `;
export type CreateColumnMutationFn = ApolloReactCommon.MutationFunction<CreateColumnMutation, CreateColumnMutationVariables>;

/**
 * __useCreateColumnMutation__
 *
 * To run a mutation, you first call `useCreateColumnMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateColumnMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createColumnMutation, { data, loading, error }] = useCreateColumnMutation({
 *   variables: {
 *      column: // value for 'column'
 *   },
 * });
 */
export function useCreateColumnMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<CreateColumnMutation, CreateColumnMutationVariables>) {
        return ApolloReactHooks.useMutation<CreateColumnMutation, CreateColumnMutationVariables>(CreateColumnDocument, baseOptions);
      }
export type CreateColumnMutationHookResult = ReturnType<typeof useCreateColumnMutation>;
export type CreateColumnMutationResult = ApolloReactCommon.MutationResult<CreateColumnMutation>;
export type CreateColumnMutationOptions = ApolloReactCommon.BaseMutationOptions<CreateColumnMutation, CreateColumnMutationVariables>;
export const CreateCardDocument = gql`
    mutation CreateCard($card: CreateCardType!) {
  createCard(input: $card) {
    id
  }
}
    `;
export type CreateCardMutationFn = ApolloReactCommon.MutationFunction<CreateCardMutation, CreateCardMutationVariables>;

/**
 * __useCreateCardMutation__
 *
 * To run a mutation, you first call `useCreateCardMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateCardMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createCardMutation, { data, loading, error }] = useCreateCardMutation({
 *   variables: {
 *      card: // value for 'card'
 *   },
 * });
 */
export function useCreateCardMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<CreateCardMutation, CreateCardMutationVariables>) {
        return ApolloReactHooks.useMutation<CreateCardMutation, CreateCardMutationVariables>(CreateCardDocument, baseOptions);
      }
export type CreateCardMutationHookResult = ReturnType<typeof useCreateCardMutation>;
export type CreateCardMutationResult = ApolloReactCommon.MutationResult<CreateCardMutation>;
export type CreateCardMutationOptions = ApolloReactCommon.BaseMutationOptions<CreateCardMutation, CreateCardMutationVariables>;
export const DeleteCardDocument = gql`
    mutation DeleteCard($card: DeleteCardType!) {
  deleteCard(input: $card) {
    id
  }
}
    `;
export type DeleteCardMutationFn = ApolloReactCommon.MutationFunction<DeleteCardMutation, DeleteCardMutationVariables>;

/**
 * __useDeleteCardMutation__
 *
 * To run a mutation, you first call `useDeleteCardMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useDeleteCardMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [deleteCardMutation, { data, loading, error }] = useDeleteCardMutation({
 *   variables: {
 *      card: // value for 'card'
 *   },
 * });
 */
export function useDeleteCardMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<DeleteCardMutation, DeleteCardMutationVariables>) {
        return ApolloReactHooks.useMutation<DeleteCardMutation, DeleteCardMutationVariables>(DeleteCardDocument, baseOptions);
      }
export type DeleteCardMutationHookResult = ReturnType<typeof useDeleteCardMutation>;
export type DeleteCardMutationResult = ApolloReactCommon.MutationResult<DeleteCardMutation>;
export type DeleteCardMutationOptions = ApolloReactCommon.BaseMutationOptions<DeleteCardMutation, DeleteCardMutationVariables>;
export const DeleteColumnDocument = gql`
    mutation DeleteColumn($column: DeleteColumnType!) {
  deleteColumn(input: $column) {
    id
  }
}
    `;
export type DeleteColumnMutationFn = ApolloReactCommon.MutationFunction<DeleteColumnMutation, DeleteColumnMutationVariables>;

/**
 * __useDeleteColumnMutation__
 *
 * To run a mutation, you first call `useDeleteColumnMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useDeleteColumnMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [deleteColumnMutation, { data, loading, error }] = useDeleteColumnMutation({
 *   variables: {
 *      column: // value for 'column'
 *   },
 * });
 */
export function useDeleteColumnMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<DeleteColumnMutation, DeleteColumnMutationVariables>) {
        return ApolloReactHooks.useMutation<DeleteColumnMutation, DeleteColumnMutationVariables>(DeleteColumnDocument, baseOptions);
      }
export type DeleteColumnMutationHookResult = ReturnType<typeof useDeleteColumnMutation>;
export type DeleteColumnMutationResult = ApolloReactCommon.MutationResult<DeleteColumnMutation>;
export type DeleteColumnMutationOptions = ApolloReactCommon.BaseMutationOptions<DeleteColumnMutation, DeleteColumnMutationVariables>;
export const UpdateCardDocument = gql`
    mutation UpdateCard($card: UpdateCardType!) {
  updateCard(input: $card) {
    content
  }
}
    `;
export type UpdateCardMutationFn = ApolloReactCommon.MutationFunction<UpdateCardMutation, UpdateCardMutationVariables>;

/**
 * __useUpdateCardMutation__
 *
 * To run a mutation, you first call `useUpdateCardMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useUpdateCardMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [updateCardMutation, { data, loading, error }] = useUpdateCardMutation({
 *   variables: {
 *      card: // value for 'card'
 *   },
 * });
 */
export function useUpdateCardMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<UpdateCardMutation, UpdateCardMutationVariables>) {
        return ApolloReactHooks.useMutation<UpdateCardMutation, UpdateCardMutationVariables>(UpdateCardDocument, baseOptions);
      }
export type UpdateCardMutationHookResult = ReturnType<typeof useUpdateCardMutation>;
export type UpdateCardMutationResult = ApolloReactCommon.MutationResult<UpdateCardMutation>;
export type UpdateCardMutationOptions = ApolloReactCommon.BaseMutationOptions<UpdateCardMutation, UpdateCardMutationVariables>;
export const ReadColumnsDocument = gql`
    query ReadColumns($boardId: ID) {
  boards(id: $boardId) {
    columns {
      id
      name
      cards {
        id
        name
        description
      }
    }
  }
}
    `;

/**
 * __useReadColumnsQuery__
 *
 * To run a query within a React component, call `useReadColumnsQuery` and pass it any options that fit your needs.
 * When your component renders, `useReadColumnsQuery` returns an object from Apollo Client that contains loading, error, and data properties 
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useReadColumnsQuery({
 *   variables: {
 *      boardId: // value for 'boardId'
 *   },
 * });
 */
export function useReadColumnsQuery(baseOptions?: ApolloReactHooks.QueryHookOptions<ReadColumnsQuery, ReadColumnsQueryVariables>) {
        return ApolloReactHooks.useQuery<ReadColumnsQuery, ReadColumnsQueryVariables>(ReadColumnsDocument, baseOptions);
      }
export function useReadColumnsLazyQuery(baseOptions?: ApolloReactHooks.LazyQueryHookOptions<ReadColumnsQuery, ReadColumnsQueryVariables>) {
          return ApolloReactHooks.useLazyQuery<ReadColumnsQuery, ReadColumnsQueryVariables>(ReadColumnsDocument, baseOptions);
        }
export type ReadColumnsQueryHookResult = ReturnType<typeof useReadColumnsQuery>;
export type ReadColumnsLazyQueryHookResult = ReturnType<typeof useReadColumnsLazyQuery>;
export type ReadColumnsQueryResult = ApolloReactCommon.QueryResult<ReadColumnsQuery, ReadColumnsQueryVariables>;
export const CreateOrganizationDocument = gql`
    mutation CreateOrganization($organization: CreateOrganizationType!) {
  createOrganization(input: $organization) {
    id
  }
}
    `;
export type CreateOrganizationMutationFn = ApolloReactCommon.MutationFunction<CreateOrganizationMutation, CreateOrganizationMutationVariables>;

/**
 * __useCreateOrganizationMutation__
 *
 * To run a mutation, you first call `useCreateOrganizationMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateOrganizationMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createOrganizationMutation, { data, loading, error }] = useCreateOrganizationMutation({
 *   variables: {
 *      organization: // value for 'organization'
 *   },
 * });
 */
export function useCreateOrganizationMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<CreateOrganizationMutation, CreateOrganizationMutationVariables>) {
        return ApolloReactHooks.useMutation<CreateOrganizationMutation, CreateOrganizationMutationVariables>(CreateOrganizationDocument, baseOptions);
      }
export type CreateOrganizationMutationHookResult = ReturnType<typeof useCreateOrganizationMutation>;
export type CreateOrganizationMutationResult = ApolloReactCommon.MutationResult<CreateOrganizationMutation>;
export type CreateOrganizationMutationOptions = ApolloReactCommon.BaseMutationOptions<CreateOrganizationMutation, CreateOrganizationMutationVariables>;
export const CreateBoardDocument = gql`
    mutation CreateBoard($board: CreateBoardType!) {
  createBoard(input: $board) {
    id
  }
}
    `;
export type CreateBoardMutationFn = ApolloReactCommon.MutationFunction<CreateBoardMutation, CreateBoardMutationVariables>;

/**
 * __useCreateBoardMutation__
 *
 * To run a mutation, you first call `useCreateBoardMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateBoardMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createBoardMutation, { data, loading, error }] = useCreateBoardMutation({
 *   variables: {
 *      board: // value for 'board'
 *   },
 * });
 */
export function useCreateBoardMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<CreateBoardMutation, CreateBoardMutationVariables>) {
        return ApolloReactHooks.useMutation<CreateBoardMutation, CreateBoardMutationVariables>(CreateBoardDocument, baseOptions);
      }
export type CreateBoardMutationHookResult = ReturnType<typeof useCreateBoardMutation>;
export type CreateBoardMutationResult = ApolloReactCommon.MutationResult<CreateBoardMutation>;
export type CreateBoardMutationOptions = ApolloReactCommon.BaseMutationOptions<CreateBoardMutation, CreateBoardMutationVariables>;
export const ReadBoardsDocument = gql`
    query ReadBoards {
  boards {
    id
    name
  }
}
    `;

/**
 * __useReadBoardsQuery__
 *
 * To run a query within a React component, call `useReadBoardsQuery` and pass it any options that fit your needs.
 * When your component renders, `useReadBoardsQuery` returns an object from Apollo Client that contains loading, error, and data properties 
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useReadBoardsQuery({
 *   variables: {
 *   },
 * });
 */
export function useReadBoardsQuery(baseOptions?: ApolloReactHooks.QueryHookOptions<ReadBoardsQuery, ReadBoardsQueryVariables>) {
        return ApolloReactHooks.useQuery<ReadBoardsQuery, ReadBoardsQueryVariables>(ReadBoardsDocument, baseOptions);
      }
export function useReadBoardsLazyQuery(baseOptions?: ApolloReactHooks.LazyQueryHookOptions<ReadBoardsQuery, ReadBoardsQueryVariables>) {
          return ApolloReactHooks.useLazyQuery<ReadBoardsQuery, ReadBoardsQueryVariables>(ReadBoardsDocument, baseOptions);
        }
export type ReadBoardsQueryHookResult = ReturnType<typeof useReadBoardsQuery>;
export type ReadBoardsLazyQueryHookResult = ReturnType<typeof useReadBoardsLazyQuery>;
export type ReadBoardsQueryResult = ApolloReactCommon.QueryResult<ReadBoardsQuery, ReadBoardsQueryVariables>;
export const DeleteInviteDocument = gql`
    mutation DeleteInvite($inviteId: Guid!) {
  deleteInvite(id: $inviteId) {
    id
  }
}
    `;
export type DeleteInviteMutationFn = ApolloReactCommon.MutationFunction<DeleteInviteMutation, DeleteInviteMutationVariables>;

/**
 * __useDeleteInviteMutation__
 *
 * To run a mutation, you first call `useDeleteInviteMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useDeleteInviteMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [deleteInviteMutation, { data, loading, error }] = useDeleteInviteMutation({
 *   variables: {
 *      inviteId: // value for 'inviteId'
 *   },
 * });
 */
export function useDeleteInviteMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<DeleteInviteMutation, DeleteInviteMutationVariables>) {
        return ApolloReactHooks.useMutation<DeleteInviteMutation, DeleteInviteMutationVariables>(DeleteInviteDocument, baseOptions);
      }
export type DeleteInviteMutationHookResult = ReturnType<typeof useDeleteInviteMutation>;
export type DeleteInviteMutationResult = ApolloReactCommon.MutationResult<DeleteInviteMutation>;
export type DeleteInviteMutationOptions = ApolloReactCommon.BaseMutationOptions<DeleteInviteMutation, DeleteInviteMutationVariables>;
export const CreateInviteDocument = gql`
    mutation createInvite($invite: CreateInviteType!) {
  createInvite(input: $invite) {
    id
  }
}
    `;
export type CreateInviteMutationFn = ApolloReactCommon.MutationFunction<CreateInviteMutation, CreateInviteMutationVariables>;

/**
 * __useCreateInviteMutation__
 *
 * To run a mutation, you first call `useCreateInviteMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateInviteMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createInviteMutation, { data, loading, error }] = useCreateInviteMutation({
 *   variables: {
 *      invite: // value for 'invite'
 *   },
 * });
 */
export function useCreateInviteMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<CreateInviteMutation, CreateInviteMutationVariables>) {
        return ApolloReactHooks.useMutation<CreateInviteMutation, CreateInviteMutationVariables>(CreateInviteDocument, baseOptions);
      }
export type CreateInviteMutationHookResult = ReturnType<typeof useCreateInviteMutation>;
export type CreateInviteMutationResult = ApolloReactCommon.MutationResult<CreateInviteMutation>;
export type CreateInviteMutationOptions = ApolloReactCommon.BaseMutationOptions<CreateInviteMutation, CreateInviteMutationVariables>;
export const ReadInvitesDocument = gql`
    query ReadInvites {
  invites {
    id
    role
    dueDate
    description
    secret
    account {
      id
      firstName
      lastName
    }
  }
}
    `;

/**
 * __useReadInvitesQuery__
 *
 * To run a query within a React component, call `useReadInvitesQuery` and pass it any options that fit your needs.
 * When your component renders, `useReadInvitesQuery` returns an object from Apollo Client that contains loading, error, and data properties 
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useReadInvitesQuery({
 *   variables: {
 *   },
 * });
 */
export function useReadInvitesQuery(baseOptions?: ApolloReactHooks.QueryHookOptions<ReadInvitesQuery, ReadInvitesQueryVariables>) {
        return ApolloReactHooks.useQuery<ReadInvitesQuery, ReadInvitesQueryVariables>(ReadInvitesDocument, baseOptions);
      }
export function useReadInvitesLazyQuery(baseOptions?: ApolloReactHooks.LazyQueryHookOptions<ReadInvitesQuery, ReadInvitesQueryVariables>) {
          return ApolloReactHooks.useLazyQuery<ReadInvitesQuery, ReadInvitesQueryVariables>(ReadInvitesDocument, baseOptions);
        }
export type ReadInvitesQueryHookResult = ReturnType<typeof useReadInvitesQuery>;
export type ReadInvitesLazyQueryHookResult = ReturnType<typeof useReadInvitesLazyQuery>;
export type ReadInvitesQueryResult = ApolloReactCommon.QueryResult<ReadInvitesQuery, ReadInvitesQueryVariables>;
export const ReadAccountsDocument = gql`
    query ReadAccounts {
  accounts {
    id
    email
    login
    role
    firstName
    lastName
    middleName
  }
}
    `;

/**
 * __useReadAccountsQuery__
 *
 * To run a query within a React component, call `useReadAccountsQuery` and pass it any options that fit your needs.
 * When your component renders, `useReadAccountsQuery` returns an object from Apollo Client that contains loading, error, and data properties 
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useReadAccountsQuery({
 *   variables: {
 *   },
 * });
 */
export function useReadAccountsQuery(baseOptions?: ApolloReactHooks.QueryHookOptions<ReadAccountsQuery, ReadAccountsQueryVariables>) {
        return ApolloReactHooks.useQuery<ReadAccountsQuery, ReadAccountsQueryVariables>(ReadAccountsDocument, baseOptions);
      }
export function useReadAccountsLazyQuery(baseOptions?: ApolloReactHooks.LazyQueryHookOptions<ReadAccountsQuery, ReadAccountsQueryVariables>) {
          return ApolloReactHooks.useLazyQuery<ReadAccountsQuery, ReadAccountsQueryVariables>(ReadAccountsDocument, baseOptions);
        }
export type ReadAccountsQueryHookResult = ReturnType<typeof useReadAccountsQuery>;
export type ReadAccountsLazyQueryHookResult = ReturnType<typeof useReadAccountsLazyQuery>;
export type ReadAccountsQueryResult = ApolloReactCommon.QueryResult<ReadAccountsQuery, ReadAccountsQueryVariables>;
export const LoginAccountDocument = gql`
    mutation LoginAccount($account: LoginAccountType!) {
  loginAccount(input: $account) {
    id
  }
}
    `;
export type LoginAccountMutationFn = ApolloReactCommon.MutationFunction<LoginAccountMutation, LoginAccountMutationVariables>;

/**
 * __useLoginAccountMutation__
 *
 * To run a mutation, you first call `useLoginAccountMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useLoginAccountMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [loginAccountMutation, { data, loading, error }] = useLoginAccountMutation({
 *   variables: {
 *      account: // value for 'account'
 *   },
 * });
 */
export function useLoginAccountMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<LoginAccountMutation, LoginAccountMutationVariables>) {
        return ApolloReactHooks.useMutation<LoginAccountMutation, LoginAccountMutationVariables>(LoginAccountDocument, baseOptions);
      }
export type LoginAccountMutationHookResult = ReturnType<typeof useLoginAccountMutation>;
export type LoginAccountMutationResult = ApolloReactCommon.MutationResult<LoginAccountMutation>;
export type LoginAccountMutationOptions = ApolloReactCommon.BaseMutationOptions<LoginAccountMutation, LoginAccountMutationVariables>;
export const ReadProfileDocument = gql`
    query ReadProfile($accountID: ID) {
  accounts(id: $accountID) {
    id
    login
    email
    organization {
      id
      name
    }
    role
    firstName
    lastName
    middleName
    assignments {
      column {
        cards {
          id
          name
          dueDate
        }
      }
    }
  }
}
    `;

/**
 * __useReadProfileQuery__
 *
 * To run a query within a React component, call `useReadProfileQuery` and pass it any options that fit your needs.
 * When your component renders, `useReadProfileQuery` returns an object from Apollo Client that contains loading, error, and data properties 
 * you can use to render your UI.
 *
 * @param baseOptions options that will be passed into the query, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options;
 *
 * @example
 * const { data, loading, error } = useReadProfileQuery({
 *   variables: {
 *      accountID: // value for 'accountID'
 *   },
 * });
 */
export function useReadProfileQuery(baseOptions?: ApolloReactHooks.QueryHookOptions<ReadProfileQuery, ReadProfileQueryVariables>) {
        return ApolloReactHooks.useQuery<ReadProfileQuery, ReadProfileQueryVariables>(ReadProfileDocument, baseOptions);
      }
export function useReadProfileLazyQuery(baseOptions?: ApolloReactHooks.LazyQueryHookOptions<ReadProfileQuery, ReadProfileQueryVariables>) {
          return ApolloReactHooks.useLazyQuery<ReadProfileQuery, ReadProfileQueryVariables>(ReadProfileDocument, baseOptions);
        }
export type ReadProfileQueryHookResult = ReturnType<typeof useReadProfileQuery>;
export type ReadProfileLazyQueryHookResult = ReturnType<typeof useReadProfileLazyQuery>;
export type ReadProfileQueryResult = ApolloReactCommon.QueryResult<ReadProfileQuery, ReadProfileQueryVariables>;
export const CreateAccountDocument = gql`
    mutation CreateAccount($secret: Guid!, $account: CreateAccountType!) {
  createAccount(secret: $secret, input: $account) {
    id
  }
}
    `;
export type CreateAccountMutationFn = ApolloReactCommon.MutationFunction<CreateAccountMutation, CreateAccountMutationVariables>;

/**
 * __useCreateAccountMutation__
 *
 * To run a mutation, you first call `useCreateAccountMutation` within a React component and pass it any options that fit your needs.
 * When your component renders, `useCreateAccountMutation` returns a tuple that includes:
 * - A mutate function that you can call at any time to execute the mutation
 * - An object with fields that represent the current status of the mutation's execution
 *
 * @param baseOptions options that will be passed into the mutation, supported options are listed on: https://www.apollographql.com/docs/react/api/react-hooks/#options-2;
 *
 * @example
 * const [createAccountMutation, { data, loading, error }] = useCreateAccountMutation({
 *   variables: {
 *      secret: // value for 'secret'
 *      account: // value for 'account'
 *   },
 * });
 */
export function useCreateAccountMutation(baseOptions?: ApolloReactHooks.MutationHookOptions<CreateAccountMutation, CreateAccountMutationVariables>) {
        return ApolloReactHooks.useMutation<CreateAccountMutation, CreateAccountMutationVariables>(CreateAccountDocument, baseOptions);
      }
export type CreateAccountMutationHookResult = ReturnType<typeof useCreateAccountMutation>;
export type CreateAccountMutationResult = ApolloReactCommon.MutationResult<CreateAccountMutation>;
export type CreateAccountMutationOptions = ApolloReactCommon.BaseMutationOptions<CreateAccountMutation, CreateAccountMutationVariables>;