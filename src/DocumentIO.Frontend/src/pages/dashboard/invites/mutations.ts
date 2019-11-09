import { gql } from 'apollo-boost'
import { CreateInviteType } from './types'

export const CreateInvite = gql`
mutation createInvite($invite: CreateInviteType!){
  createInvite(input: $invite){
    id
  }
}
`

export interface CreateInviteVariables {
  invite: CreateInviteType
}