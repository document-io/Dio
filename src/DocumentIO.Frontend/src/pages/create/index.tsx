import React from 'react'
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"
import { MenuHeader } from "../../components/header"
import { RouteComponentProps } from 'react-router'

import { CreatePageTemplate } from "./template"

export const CreatePage = (props: RouteComponentProps) => (
	<React.Fragment>
		<MenuHeader logoUrl='/'>
			<Menu.Item as={ Link } to='login'>
				Войти
			</Menu.Item>
		</MenuHeader>

		<CreatePageTemplate {...props} />
	</React.Fragment>
)
