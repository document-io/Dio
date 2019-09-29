import { gql } from "apollo-boost"
import { ReadBoardType } from "./types"

export const Boards = gql`
query ReadBoards {
  boards {
    id
    name
  }
}
`

export interface ReadBoardsResponse {
	boards: ReadBoardType[]
}