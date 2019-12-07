/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { CreateInviteType } from "./../../../../../__generated__/globalTypes";

// ====================================================
// GraphQL mutation operation: createInvite
// ====================================================

export interface createInvite_createInvite {
  __typename: "ReadInviteType";
  id: string;
}

export interface createInvite {
  createInvite: createInvite_createInvite | null;
}

export interface createInviteVariables {
  invite: CreateInviteType;
}
