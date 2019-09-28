import React from "react"
import { Dropdown, Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"
import { LogoutTemplate } from "./logout"
import { RouteChildrenProps } from 'react-router'

export const DocumentIOMenuDropdown = (props: RouteChildrenProps) => (
	<Menu.Menu position='right'>
		<Dropdown item text='Аккаунт'>
			<Dropdown.Menu>
				<Dropdown.Item as={Link} to='/dashboard'>Дашборд</Dropdown.Item>
				<Dropdown.Item>Мои карточки</Dropdown.Item>
				<Dropdown.Item>Уведомления</Dropdown.Item>
				<Dropdown.Item>Настройки</Dropdown.Item>
				<Dropdown.Divider/>
				<LogoutTemplate {...props}/>
			</Dropdown.Menu>
		</Dropdown>
	</Menu.Menu>
)