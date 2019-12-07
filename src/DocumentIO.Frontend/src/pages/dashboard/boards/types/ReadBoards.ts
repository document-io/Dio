/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: ReadBoards
// ====================================================

export interface ReadBoards_boards {
  __typename: "ReadBoardType";
  id: string;
  name: string;
}

export interface ReadBoards {
  boards: (ReadBoards_boards | null)[] | null;
}
