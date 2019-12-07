/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

import { CreateCardType } from "./../../../types/graphql-global-types";

// ====================================================
// GraphQL mutation operation: CreateCard
// ====================================================

export interface CreateCard_createCard {
  __typename: "ReadCardType";
  id: string;
}

export interface CreateCard {
  createCard: CreateCard_createCard | null;
}

export interface CreateCardVariables {
  card: CreateCardType;
}
