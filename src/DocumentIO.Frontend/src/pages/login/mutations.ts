import { gql } from "apollo-boost"
import { LoginAccountType } from "./types"

export const LoginAccount = gql`
mutation LoginAccount($account: LoginAccountType!) {
  loginAccount(input: $account) {
    id
  }
}
`

export interface LoginAccountVariables {
	account: LoginAccountType
}