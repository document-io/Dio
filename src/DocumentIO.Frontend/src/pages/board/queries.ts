import { gql } from 'apollo-boost'
import { ReadBoards } from './types'

export const Columns = gql`
query ReadColumns($boardId: ID){
  boards(id: $boardId) {  
    columns {
      id,
      name,
      cards {
        id,
        name
      }
    }
  }
}
`

export interface ReadBoardsVariables {
  boards: ReadBoards[]
}