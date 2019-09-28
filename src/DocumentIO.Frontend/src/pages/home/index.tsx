import React from 'react'
import { MenuHeader } from "../../components/header"
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"

export const HomePage = () => {
	return (
		<React.Fragment>
			<MenuHeader logoUrl='/'>
				<Menu.Item as={Link} to='login'>
					Войти
				</Menu.Item>

				<Menu.Item as={Link} to='create'>
					Создать организацию
				</Menu.Item>
			</MenuHeader>

			<div>Home</div>
		</React.Fragment>
	)
}