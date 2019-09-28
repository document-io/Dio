import { gql } from "apollo-boost"
import { CreateOrganizationType } from "./types"

export const CreateOrganization = gql`
	mutation CreateOrganization($organization: CreateOrganizationType!) {
		createOrganization(input: $organization) {
			id
		}
	}
`

export interface CreateOrganizationVariables {
	organization: CreateOrganizationType
}