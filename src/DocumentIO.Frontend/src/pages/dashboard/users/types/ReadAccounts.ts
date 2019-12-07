/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: ReadAccounts
// ====================================================

export interface ReadAccounts_accounts {
  __typename: "ReadAccountType";
  id: string;
  email: string;
  login: string;
  role: string;
  firstName: string;
  lastName: string;
  middleName: string | null;
}

export interface ReadAccounts {
  accounts: (ReadAccounts_accounts | null)[] | null;
}
