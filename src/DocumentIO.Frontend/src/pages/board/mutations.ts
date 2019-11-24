import { gql } from 'apollo-boost'
import { CreateCardType, CreateColumnType } from './types'

export const CreateColumn = gql`
	mutation CreateColumn($column: CreateColumnType!) {
		createColumn(input: $column) {
			id
		}
	}
`
export const CreateCard = gql`
	mutation CreateCard($card: CreateCardType!) {
		createCard(input: $card) {
			id
		}
	}
`

export interface CreateColumnVariables {
  column: CreateColumnType
}

export interface CreateCardVariables {
  card: CreateCardType
}