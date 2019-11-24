import React from 'react'
import { RouteChildrenProps } from 'react-router'
import { Container, Grid, Tab } from 'semantic-ui-react'

import { DocumentIOMenu } from '../../components/menu'
import { DashboardBoardsTab } from './boards'
import { DashboardUsersTab } from './users'
import { DashboardInviteTab } from './invites'

export const DashboardPage = (props: RouteChildrenProps) => {
  const defaultActiveIndex = getDefaultActiveIndex(props.location.search, props)

  return (
    <React.Fragment>
      <DocumentIOMenu logoUrl='/dashboard' search dropdown {...props}/>

      <Grid centered>
        <Grid.Column textAlign='center'>
          <Container>
            <Tab menu={{ pointing: true, compact: true }}
                 panes={panes(props)}
                 defaultActiveIndex={defaultActiveIndex}
                 onTabChange={(event, data) => {
                   // @ts-ignore
                   props.history.replace({ search: `tab=${data.panes[data.activeIndex].menuItem.key}` })
                 }}
            />
          </Container>
        </Grid.Column>
      </Grid>
    </React.Fragment>
  )
}

const panes = (props: RouteChildrenProps): Array<{
  menuItem: {
    key: string, icon: string, content: string
  }, render: () => React.ReactNode
}> => [
  {
    menuItem: { key: 'boards', icon: 'table', content: 'Доски' },
    render: () => (
      <Tab.Pane attached={false}>
        <DashboardBoardsTab {...props}/>
      </Tab.Pane>)
  },
  {
    menuItem: { key: 'users', icon: 'users', content: 'Сотрудники' },
    render: () => (
      <Tab.Pane attached={false}>
        <DashboardUsersTab {...props}/>
      </Tab.Pane>)
  },
  {
    menuItem: { key: 'invites', icon: 'sitemap', content: 'Приглашения' },
    render: () => (
      <Tab.Pane attached={false}>
        <DashboardInviteTab {...props}/>
      </Tab.Pane>)
  }
]

const getDefaultActiveIndex = (search: string, props: RouteChildrenProps) => {

  const query = new URLSearchParams(search)
  const tab = query.get('tab')
  const panesVariables = panes(props)

  for (let i = 0; i < panesVariables.length; i++) {
    if (panesVariables[i].menuItem.key === tab) {
      return i
    }
  }

  return 0
}