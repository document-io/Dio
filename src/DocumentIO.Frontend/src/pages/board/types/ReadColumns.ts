/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: ReadColumns
// ====================================================

export interface ReadColumns_boards_columns_cards {
  __typename: "ReadCardType";
  id: string;
  name: string;
  description: string | null;
}

export interface ReadColumns_boards_columns {
  __typename: "ReadColumnType";
  id: string;
  name: string;
  cards: (ReadColumns_boards_columns_cards | null)[] | null;
}

export interface ReadColumns_boards {
  __typename: "ReadBoardType";
  columns: (ReadColumns_boards_columns | null)[] | null;
}

export interface ReadColumns {
  boards: (ReadColumns_boards | null)[] | null;
}

export interface ReadColumnsVariables {
  boardId?: string | null;
}
