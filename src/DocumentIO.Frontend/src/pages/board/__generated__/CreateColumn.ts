/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { CreateColumnType } from "./../../../../__generated__/globalTypes";

// ====================================================
// GraphQL mutation operation: CreateColumn
// ====================================================

export interface CreateColumn_createColumn {
  __typename: "ReadColumnType";
  id: string;
}

export interface CreateColumn {
  createColumn: CreateColumn_createColumn | null;
}

export interface CreateColumnVariables {
  column: CreateColumnType;
}
