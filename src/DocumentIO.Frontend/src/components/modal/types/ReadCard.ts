/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

// ====================================================
// GraphQL query operation: ReadCard
// ====================================================

export interface ReadCard_cards_assignments {
  __typename: "ReadAccountType";
  firstName: string;
  lastName: string;
}

export interface ReadCard_cards_comments_account {
  __typename: "ReadAccountType";
  firstName: string;
  lastName: string;
}

export interface ReadCard_cards_comments {
  __typename: "ReadCommentType";
  id: string;
  text: string;
  account: ReadCard_cards_comments_account;
}

export interface ReadCard_cards {
  __typename: "ReadCardType";
  name: string;
  content: string | null;
  description: string | null;
  dueDate: any | null;
  createdAt: any;
  assignments: (ReadCard_cards_assignments | null)[] | null;
  comments: (ReadCard_cards_comments | null)[] | null;
}

export interface ReadCard {
  cards: (ReadCard_cards | null)[] | null;
}

export interface ReadCardVariables {
  cardId?: string | null;
}
