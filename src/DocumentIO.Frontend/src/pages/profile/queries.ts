import {gql} from "apollo-boost";
import {ReadAccountType} from "./types";

export const ReadProfile = gql`
query ReadProfile($accountID: ID) {
  accounts(id: $accountID) {
    id
    login
    email
    organization {
      id
      name
    }
    role
    firstName
    lastName
    middleName
    assignments {
      column {
        cards{
          id,
          name,
          dueDate
        }
      }
    }
  }
}
`

export interface ReadProfileVariables {
    accounts: ReadAccountType[]
}