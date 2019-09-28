import { gql } from "apollo-boost"

export const LogoutAccount = gql`
mutation LogoutAccount {
	logoutAccount {
		id
	}
}
`