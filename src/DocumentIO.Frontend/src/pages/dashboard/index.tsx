import React from "react"
import { Grid, Tab } from "semantic-ui-react"

import { DocumentIOMenu } from "../../components/menu"
import { DashboardBoardsTab } from "./boards"
import { DashboardUsersTab } from "./users"
import { DashboardInviteTab } from "./invites"
import { RouteChildrenProps } from 'react-router'

export const DashboardPage = (props: RouteChildrenProps) => {
	return (
		<React.Fragment>
			<DocumentIOMenu logoUrl='/dashboard' search dropdown {...props}/>

			<Grid centered>
				<Grid.Column textAlign='center'>
					<Tab menu={ {pointing: true, compact: true} } panes={ panes }/>
				</Grid.Column>
			</Grid>
		</React.Fragment>
	)
}

const panes = [
	{
		menuItem: {key: 'boards', icon: 'table', content: 'Доски'},
		render: () => (
			<Tab.Pane attached={ false }>
				<DashboardBoardsTab/>
			</Tab.Pane>),
	},
	{
		menuItem: {key: 'users', icon: 'users', content: 'Пользователи'},
		render: () => (
			<Tab.Pane attached={ false }>
				<DashboardUsersTab/>
			</Tab.Pane>),
	},
	{
		menuItem: {key: 'invites', icon: 'sitemap', content: 'Приглашения'},
		render: () => (
			<Tab.Pane attached={ false }>
				<DashboardInviteTab/>
			</Tab.Pane>),
	},
]