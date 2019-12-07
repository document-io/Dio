/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { CreateBoardType } from "./../../../../types/graphql-global-types";

// ====================================================
// GraphQL mutation operation: CreateBoard
// ====================================================

export interface CreateBoard_createBoard {
  __typename: "ReadBoardType";
  id: string;
}

export interface CreateBoard {
  createBoard: CreateBoard_createBoard | null;
}

export interface CreateBoardVariables {
  board: CreateBoardType;
}
