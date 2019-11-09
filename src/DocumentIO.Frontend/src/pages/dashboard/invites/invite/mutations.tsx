import { gql } from 'apollo-boost'

export const DeleteInvite = gql`
mutation DeleteInvite($inviteId: Guid!) {
  deleteInvite(id: $inviteId) {
    id
  }
}
`

export interface DeleteInviteVariables {
  inviteId: string
}

