import { gql } from 'apollo-boost'
import { CreateBoardType } from './types'

export const CreateBoard = gql`
mutation CreateBoard($board: CreateBoardType!) {
  createBoard(input: $board) {
    id
  }
}
`

export interface CreateBoardVariables {
  board: CreateBoardType
}