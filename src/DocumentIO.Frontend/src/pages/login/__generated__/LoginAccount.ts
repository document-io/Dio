/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { LoginAccountType } from "./../../../../__generated__/globalTypes";

// ====================================================
// GraphQL mutation operation: LoginAccount
// ====================================================

export interface LoginAccount_loginAccount {
  __typename: "ReadAccountType";
  id: string;
}

export interface LoginAccount {
  loginAccount: LoginAccount_loginAccount | null;
}

export interface LoginAccountVariables {
  account: LoginAccountType;
}
