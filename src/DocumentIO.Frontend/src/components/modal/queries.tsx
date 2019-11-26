import { gql } from 'apollo-boost'
import { ReadCardType } from './types'

export const ReadCard = gql`
query ReadCard($cardId: ID) {
  cards(id: $cardId) {
    name
    content
    description
    dueDate
    createdAt
    assignments {
      firstName
      lastName
    }
    comments {
      id
      text
      account {
        firstName
        lastName
      }
    }
  }
}
`

export interface ReadCardVariables {
  cards: ReadCardType[]
}