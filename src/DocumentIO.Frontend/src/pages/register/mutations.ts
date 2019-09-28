import { gql } from "apollo-boost"
import { CreateAccountType } from "./types"

export const CreateAccount = gql`
mutation CreateAccount($secret: Guid!, $account: CreateAccountType!) {
  createAccount(secret: $secret, input: $account) {
    id
  }
}
`

export interface CreateAccountVariables {
	secret: string;
	account: CreateAccountType
}