/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { CreateOrganizationType } from "./../../../../__generated__/globalTypes";

// ====================================================
// GraphQL mutation operation: CreateOrganization
// ====================================================

export interface CreateOrganization_createOrganization {
  __typename: "ReadOrganizationType";
  id: string;
}

export interface CreateOrganization {
  createOrganization: CreateOrganization_createOrganization | null;
}

export interface CreateOrganizationVariables {
  organization: CreateOrganizationType;
}
