import React from 'react'
import { DocumentIOMenu } from "../../components/menu"
import { Menu } from "semantic-ui-react"
import { Link, RouteComponentProps } from "react-router-dom"
import { LoginPageTemplate } from "./template"

export const LoginPage = (props: RouteComponentProps) => {

	return (
		<React.Fragment>
			<DocumentIOMenu logoUrl='/'>
				<Menu.Item as={Link} to='create'>
					Создать организацию
				</Menu.Item>
			</DocumentIOMenu>

			<LoginPageTemplate {...props}/>
		</React.Fragment>
	)
}