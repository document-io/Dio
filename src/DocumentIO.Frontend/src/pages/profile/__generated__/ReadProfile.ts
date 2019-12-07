/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: ReadProfile
// ====================================================

export interface ReadProfile_accounts_organization {
  __typename: "ReadOrganizationType";
  id: string;
  name: string;
}

export interface ReadProfile_accounts_assignments_column_cards {
  __typename: "ReadCardType";
  id: string;
  name: string;
  dueDate: any | null;
}

export interface ReadProfile_accounts_assignments_column {
  __typename: "ReadColumnType";
  cards: (ReadProfile_accounts_assignments_column_cards | null)[] | null;
}

export interface ReadProfile_accounts_assignments {
  __typename: "ReadCardType";
  column: ReadProfile_accounts_assignments_column;
}

export interface ReadProfile_accounts {
  __typename: "ReadAccountType";
  id: string;
  login: string;
  email: string;
  organization: ReadProfile_accounts_organization;
  role: string;
  firstName: string;
  lastName: string;
  middleName: string | null;
  assignments: (ReadProfile_accounts_assignments | null)[] | null;
}

export interface ReadProfile {
  accounts: (ReadProfile_accounts | null)[] | null;
}

export interface ReadProfileVariables {
  accountID?: string | null;
}
