import React from 'react'
import { Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"
import { MenuHeader } from "../../components/header"
import { RouteComponentProps } from 'react-router'

import { CreatePageContent } from "./content"

export const CreatePage = (props: RouteComponentProps) => (
	<React.Fragment>
		<MenuHeader>
			<Menu.Item as={ Link } to='login'>
				Войти
			</Menu.Item>
		</MenuHeader>

		<CreatePageContent {...props} />
	</React.Fragment>
)
