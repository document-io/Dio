import React from 'react'
import { RouteChildrenProps } from 'react-router'
// @ts-ignore
import TrelloBoard from 'react-trello'
import { DocumentIOMenu } from '../../components/menu'
import { useMutation, useQuery } from '@apollo/react-hooks'
import { CreateCard, CreateCardVariables, CreateColumn, CreateColumnVariables } from './mutations'
import { CreateCardType, CreateColumnType } from './types'
import { Columns, ReadColumnsVariables } from './queries'

export const Board = (props: RouteChildrenProps) => {
  // @ts-ignore
  const boardId = props.match.params.boardId

  const { data, loading, refetch, error } = useQuery<ReadColumnsVariables>(Columns)
  const initialData = {
    lanes: []
  }
  let updatedData = initialData
  if (!loading) {
    updatedData = {
      // @ts-ignore
      lanes: data!.columns.map(({ cards, id, name }) => ({
        id,
        title: name,
        cards: cards.map(({ name, content, id }) => ({
          id,
          title: name,
          description: content
        }))
      }))
    }
  }
  console.log(updatedData)

  const [createColumn] = useMutation<CreateColumnType, CreateColumnVariables>(CreateColumn)
  const [createCard] = useMutation<CreateCardType, CreateCardVariables>(CreateCard)


  const onLaneAdd = async ({ title }: { title: string }) => {
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

  const onLaneDelete = ({ title }: { title: string }) => {
    // TODO
  }

  const onCardAdd = async ({ title }: { title: string }, laneId: any) => {
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

  const onCardDelete = ({ title }: { title: string }) => {
    // TODO
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
      />
    </>
  )
}