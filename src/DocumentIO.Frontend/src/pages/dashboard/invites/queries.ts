import { gql } from 'apollo-boost'
import { ReadInviteType } from './types'

export const Invites = gql`
query ReadInvites{
  invites {
    id,
    role,
    dueDate,
    description,
    secret,
    account {
      id,
      firstName,
      lastName
    }
  }
}
`

export interface ReadInvitesResponse {
  invites: ReadInviteType[]
}