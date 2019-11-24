import React, { FormEvent, useState } from 'react'
import { Dimmer, Form, Grid, Loader } from 'semantic-ui-react'
import SemanticDatepicker from 'react-semantic-ui-datepickers'
import { useMutation, useQuery } from '@apollo/react-hooks'
import _sortBy from 'lodash/sortBy'
import { Invite } from './invite'
import { InviteType } from './types'
import { CreateInvite, CreateInviteVariables } from './mutations'
import { Invites, ReadInvitesResponse } from './queries'
import { RouteChildrenProps } from 'react-router'

export const DashboardInviteTab = (props: RouteChildrenProps) => {
  const { loading, error, data, refetch } = useQuery<ReadInvitesResponse>(Invites)

  const [isLoading, setLoading] = useState(false)
  const [role, setRole] = useState('')
  const [date, setDate] = useState<Date | null>(null)
  const [description, setDescription] = useState('')

  const [createInvite] = useMutation<InviteType, CreateInviteVariables>(CreateInvite)

  if (loading) {
    return (
      <Dimmer active inverted>
        <Loader size='big'/>
      </Dimmer>
    )
  }

  const filteredData = (() => {
    const first = _sortBy(
      data!.invites.filter(value => value.account),
      'dueDate'
    )
    const second = _sortBy(
      data!.invites.filter(value => !value.account),
      'dueDate'
    )
    return { invites: first.concat(second) }
  })()

  const refreshData = async () => {
    await refetch()
  }

  const onSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault()

    setLoading(true)

    try {
      await createInvite({
        variables: {
          invite: {
            description,
            role,
            dueDate: date ? date.toDateString() : new Date(Date.now()).toDateString()
          }
        }
      })
      await refreshData()
      setLoading(false)
    } catch (e) {
      setLoading(false)
    }
  }

  return (
    <Grid>
      <Grid.Column textAlign='left'>
        <Form loading={isLoading} onSubmit={onSubmit}>
          <Form.Group widths='equal'>
            <Form.Select
              label='Роли'
              placeholder='Select role'
              fluid
              options={[{ text: 'Admin', value: 'admin' }]}
              onChange={(event, data) => setRole(data.value as string)}/>
            <SemanticDatepicker
              label='Дата окончания приглашения'
              onDateChange={(date) => setDate(date as Date | null)}/>
            <Form.Input
              label='Описание'
              onChange={(event, data) => setDescription(data.value)}/>
            <Form.Button className='create-invite-button' basic color='black'>
              Создать
            </Form.Button>
          </Form.Group>
        </Form>
        {filteredData!.invites.map((invite) => <Invite key={invite.id} invite={invite} refresh={refreshData}/>)}
      </Grid.Column>
    </Grid>
  )
}