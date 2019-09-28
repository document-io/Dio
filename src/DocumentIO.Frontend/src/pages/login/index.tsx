import React from 'react'
import { MenuHeader } from "../../components/header"
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"

export const LoginPage = () => {

	return (
		<React.Fragment>
			<MenuHeader>
				<Menu.Item as={Link} to='create'>
					Создать организацию
				</Menu.Item>
			</MenuHeader>

			<div>Тут логин</div>
		</React.Fragment>
	)
}