import React from 'react'
import {RouteChildrenProps} from 'react-router'
// @ts-ignore
import TrelloBoard from 'react-trello'
import {DocumentIOMenu} from '../../components/menu'
import {useMutation, useQuery} from '@apollo/react-hooks'
import {
    CreateCard,
    CreateCardVariables,
    CreateColumn,
    CreateColumnVariables,
    DeleteCard,
    DeleteCardVariables, DeleteColumn, DeleteColumnVariables
} from './mutations'
import {CreateCardType, CreateColumnType} from './types'
import {Columns, ReadBoardsVariables} from './queries'

export const Board = (props: RouteChildrenProps) => {
    // @ts-ignore
    const boardId: string = props.match.params.boardId

    const {data, loading, refetch} = useQuery<ReadBoardsVariables>(Columns, {
        variables: {boardId}
    })
    const initialData = {
        lanes: []
    }
    let updatedData = initialData
    if (!loading) {
        updatedData = {
            // @ts-ignore
            lanes: data!.boards[0].columns.map(({cards, id, name}) => ({
                id,
                title: name,
                cards: cards.map(({name, content, id}) => ({
                    id,
                    title: name,
                    description: content
                }))
            }))
        }
    }

    const [createColumn] = useMutation<CreateColumnType, CreateColumnVariables>(CreateColumn)
    const [createCard] = useMutation<CreateCardType, CreateCardVariables>(CreateCard)
    const [deleteCard] = useMutation<{ id: string }, DeleteCardVariables>(DeleteCard)
    const [deleteColumn] = useMutation<{ id: string }, DeleteColumnVariables>(DeleteColumn)


    const onLaneAdd = async ({title}: { title: string }) => {
        try {
            await createColumn({
                variables: {
                    column: {
                        boardId,
                        name: title
                    }
                }
            })
            await refetch()
        } catch (e) {

        }
    }

    const onLaneDelete = async (laneId: string) => {
        try {
            await deleteColumn({
                variables: {
                    column: {
                        id: laneId
                    }
                }
            })
            await refetch()
        } catch (e) {

        }
    }

    const onCardAdd = async ({title}: { title: string }, laneId: any) => {
        console.log(title, laneId)
        try {
            await createCard({
                variables: {
                    card: {
                        columnId: laneId,
                        name: title
                    }
                }
            })
            await refetch()
        } catch (e) {
        }
    }

    const onCardDelete = async (cardId: string) => {
        try {
            await deleteCard({
                variables: {
                    card: {
                        id: cardId
                    }
                }
            })
            await refetch()
        } catch (e) {

        }
    }

    return loading ? null : (
        <>
            <DocumentIOMenu logoUrl='/dashboard' search dropdown {...props}/>
            <TrelloBoard
                data={updatedData}
                editable
                canAddLanes
                onLaneAdd={onLaneAdd}
                onCardAdd={onCardAdd}
                onCardDelete={onCardDelete}
                onLaneDelete={onLaneDelete}
            />
        </>
    )
}