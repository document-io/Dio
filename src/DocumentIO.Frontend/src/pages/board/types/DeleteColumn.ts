/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { DeleteColumnType } from "./../../../types/graphql-global-types";

// ====================================================
// GraphQL mutation operation: DeleteColumn
// ====================================================

export interface DeleteColumn_deleteColumn {
  __typename: "ReadColumnType";
  id: string;
}

export interface DeleteColumn {
  deleteColumn: DeleteColumn_deleteColumn | null;
}

export interface DeleteColumnVariables {
  column: DeleteColumnType;
}
