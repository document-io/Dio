import { gql } from "apollo-boost"
import { ReadAccountType } from "./types"

export const Accounts = gql`
query ReadAccounts {
  accounts {
    id
    email
    login
    role
    firstName
    lastName
    middleName
  }
}
`

export interface ReadAccountsResponse {
	accounts: ReadAccountType[]
}