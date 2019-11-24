import React, { useEffect, useState } from 'react'
import { useMutation, useQuery } from '@apollo/react-hooks'
import { Boards, ReadBoardsResponse } from './queries'
import { Card, Dimmer, Form, Icon, Loader, Message } from 'semantic-ui-react'
import { CreateBoard, CreateBoardVariables } from './mutations'
import { ReadBoardType } from './types'
import { RouteChildrenProps } from 'react-router'

export const DashboardBoardsTab = (props: RouteChildrenProps) => {
  const [globalValidation, setGlobalValidation] = useState('')
  const [boardName, setBoardName] = useState('')

  const { loading, error, data, refetch } = useQuery<ReadBoardsResponse>(Boards)

  const [createBoard] = useMutation<ReadBoardType, CreateBoardVariables>(CreateBoard)

  useEffect(() => {
    setGlobalValidation(error ? error.graphQLErrors[0].message : '')
  }, [error])

  if (loading) {
    return (
      <Dimmer active inverted>
        <Loader size='big'/>
      </Dimmer>
    )
  }

  const onSubmit = async () => {
    try {
      await createBoard({
        variables: {
          board: {
            name: boardName
          }
        }
      })
      setBoardName('')
      await refetch()
    } catch (e) {
    }
  }

  // @ts-ignore
  const items = data.boards
    .map(board => (
      <Card key={board.id} centered onClick={() => props.history.push(`/dashboard/board/${board.id}`)}>
        <Card.Content>
          <Card.Header>{board.name}</Card.Header>
          <Card.Description>Leverage agile frameworks to provide a robust synopsis for high level
            overviews.</Card.Description>
        </Card.Content>
        <Card.Content extra>
          <Icon name='user'/>4 Friends
        </Card.Content>
      </Card>
    ))
    .concat((
      <Card key='addBoard' centered>

        <Card.Content>
          <Card.Header>Добавить</Card.Header>
          <Card.Description>
            <Form onSubmit={onSubmit}>
              <Form.Input fluid placeholder='Введите название'
                          onChange={({ target }) => setBoardName(target.value)}
              />
            </Form>
          </Card.Description>
        </Card.Content>
        <Card.Content extra>
          Нажмите enter
        </Card.Content>
      </Card>
    ))

  return (
    <React.Fragment>
      {
        globalValidation === ''
          ? null
          : (
            <Message
              error
              content={globalValidation}/>
          )
      }

      <Card.Group>
        {items}
      </Card.Group>
    </React.Fragment>
  )
}