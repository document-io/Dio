/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { DeleteCardType } from "./../../../types/graphql-global-types";

// ====================================================
// GraphQL mutation operation: DeleteCard
// ====================================================

export interface DeleteCard_deleteCard {
  __typename: "ReadCardType";
  id: string;
}

export interface DeleteCard {
  deleteCard: DeleteCard_deleteCard | null;
}

export interface DeleteCardVariables {
  card: DeleteCardType;
}
