import {gql} from "apollo-boost"
import {ReadBoardType} from "./types"

export const Boards = gql`
query ReadBoards {
  boards {
    id
    name
    columns {
      cards {
        id
      }
    }
  }
}
`

export interface ReadBoardsResponse {
	boards: ReadBoardType[]
}