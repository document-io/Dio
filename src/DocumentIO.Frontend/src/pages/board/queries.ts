import { gql } from 'apollo-boost'
import { ReadColumns } from './types'

export const Columns = gql`
query ReadColumns{
  columns {
    id,
    name,
    cards {
      id,
      name,
      content
    }
  }
}
`

export interface ReadColumnsVariables {
  columns: ReadColumns[]
}