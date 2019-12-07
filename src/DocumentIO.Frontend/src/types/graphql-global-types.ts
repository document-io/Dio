/* tslint:disable */
/* eslint-disable */
// This file was automatically generated and should not be edited.

//==============================================================
// START Enums and Input Objects
//==============================================================

export interface CreateAccountType {
  login: string;
  email: string;
  password: string;
  firstName: string;
  middleName?: string | null;
  lastName: string;
}

export interface CreateBoardType {
  name: string;
}

export interface CreateCardType {
  name: string;
  description: string;
  columnId: string;
}

export interface CreateColumnType {
  name: string;
  boardId: string;
}

export interface CreateInviteType {
  role: string;
  description: string;
  dueDate?: any | null;
}

export interface CreateOrganizationType {
  name: string;
  accounts: (CreateAccountType | null)[];
}

export interface DeleteCardType {
  id: string;
}

export interface DeleteColumnType {
  id: string;
}

export interface LoginAccountType {
  email: string;
  password: string;
}

export interface UpdateCardType {
  id: string;
  columnId?: string | null;
  name?: string | null;
  order?: number | null;
  dueDate?: any | null;
  content?: string | null;
}

//==============================================================
// END Enums and Input Objects
//==============================================================
