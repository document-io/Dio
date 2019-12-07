/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { UpdateCardType } from "./../../../../__generated__/globalTypes";

// ====================================================
// GraphQL mutation operation: UpdateCard
// ====================================================

export interface UpdateCard_updateCard {
  __typename: "ReadCardType";
  content: string | null;
}

export interface UpdateCard {
  updateCard: UpdateCard_updateCard | null;
}

export interface UpdateCardVariables {
  card: UpdateCardType;
}
