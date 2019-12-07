/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { CreateAccountType } from "./../../../../__generated__/globalTypes";

// ====================================================
// GraphQL mutation operation: CreateAccount
// ====================================================

export interface CreateAccount_createAccount {
  __typename: "ReadAccountType";
  id: string;
}

export interface CreateAccount {
  createAccount: CreateAccount_createAccount | null;
}

export interface CreateAccountVariables {
  secret: any;
  account: CreateAccountType;
}
