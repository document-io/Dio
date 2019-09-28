import React from 'react'
import { DocumentIOMenu } from "../../components/menu"
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"

export const HomePage = () => {
	return (
		<React.Fragment>
			<DocumentIOMenu logoUrl='/'>
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