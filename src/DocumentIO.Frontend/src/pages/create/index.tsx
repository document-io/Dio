import React from 'react'
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"
import { DocumentIOMenu } from "../../components/menu"
import { RouteComponentProps } from 'react-router'

import { CreatePageTemplate } from "./template"

export const CreatePage = (props: RouteComponentProps) => (
	<React.Fragment>
		<DocumentIOMenu logoUrl='/' {...props}>
			<Menu.Item as={ Link } to='login'>
				Войти
			</Menu.Item>
		</DocumentIOMenu>

		<CreatePageTemplate {...props} />
	</React.Fragment>
)
