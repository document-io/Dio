import React, { useEffect, useState } from "react"
import { useQuery } from "@apollo/react-hooks"
import { Accounts, ReadAccountsResponse } from "./queries"
import { Dimmer, Loader, Message, Card, Icon, Header, Input, Form, Grid } from "semantic-ui-react"

export const DashboardUsersTab = () => {
	const [globalValidation, setGlobalValidation] = useState("")

	const { loading, error, data } = useQuery<ReadAccountsResponse>(Accounts)

	useEffect(() => {
		setGlobalValidation(error ? error.graphQLErrors[0].message : "")
	}, [error])

	if (loading) {
		return (
			<Dimmer active inverted>
				<Loader size='big' />
			</Dimmer>
		)
	}

	// @ts-ignore
	const items = data.accounts
		.map(account => (
			<Card key={account.id} centered>
				<Card.Content header={`ФИО: ${account.firstName} ${account.lastName}`} />
				<Card.Content description={`Логин: ${account.login}`} />
				<Card.Content meta={`Роль: ${account.role}`}/>
				<Card.Content extra>
					<Icon name='at' />{account.email}
				</Card.Content>
			</Card>
		))

	return (
		<React.Fragment>
			{
				globalValidation === ""
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