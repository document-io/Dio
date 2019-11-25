import {gql} from 'apollo-boost'
import {CreateCardType, CreateColumnType} from './types'

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
export const DeleteCard = gql`
	mutation DeleteCard($card: DeleteCardType!) {
		deleteCard(input: $card) {
			id
		}
	}
`
export const DeleteColumn = gql`
	mutation DeleteColumn($column: DeleteColumnType!) {
		deleteColumn(input: $column) {
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

export interface DeleteCardVariables {
    card: {
        id: string
    }
}

export interface DeleteColumnVariables {
    column: {
        id: string
    }
}