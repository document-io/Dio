import React from 'react'
import { DocumentIOMenu } from "../../components/menu"
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"

import { RouteChildrenProps } from 'react-router'

export const HomePage = (props: RouteChildrenProps) => {
	return (
		<React.Fragment>
			<DocumentIOMenu logoUrl='/' {...props}>
				<Menu.Item as={Link} to='login'>
					Войти
				</Menu.Item>

				<Menu.Item as={Link} to='create'>
					Создать организацию
				</Menu.Item>
			</DocumentIOMenu>

			<div>Home</div>
		</React.Fragment>
	)
}