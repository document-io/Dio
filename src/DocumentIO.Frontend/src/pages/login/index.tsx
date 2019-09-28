import React from 'react'
import { MenuHeader } from "../../components/header"
import { Menu } from "semantic-ui-react"
import { Link, RouteComponentProps } from "react-router-dom"
import { LoginPageTemplate } from "./template"

export const LoginPage = (props: RouteComponentProps) => {

	return (
		<React.Fragment>
			<MenuHeader logoUrl='/'>
				<Menu.Item as={Link} to='create'>
					Создать организацию
				</Menu.Item>
			</MenuHeader>

			<LoginPageTemplate {...props}/>
		</React.Fragment>
	)
}