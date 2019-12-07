/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: ReadInvites
// ====================================================

export interface ReadInvites_invites_account {
  __typename: "ReadAccountType";
  id: string;
  firstName: string;
  lastName: string;
}

export interface ReadInvites_invites {
  __typename: "ReadInviteType";
  id: string;
  role: string;
  dueDate: any | null;
  description: string;
  secret: string;
  account: ReadInvites_invites_account | null;
}

export interface ReadInvites {
  invites: (ReadInvites_invites | null)[] | null;
}
