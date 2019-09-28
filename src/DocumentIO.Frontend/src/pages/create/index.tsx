import React from 'react'
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"
import { MenuHeader } from "../../components/header"

export const CreatePage = () => (
	<React.Fragment>
		<MenuHeader>
			<Menu.Item as={Link} to='login'>
				Войти
			</Menu.Item>
		</MenuHeader>
		<div>Create</div>
	</React.Fragment>
)