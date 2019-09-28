import React from "react"
import { Dropdown, Menu } from "semantic-ui-react"
import { Link } from "react-router-dom"

export const DocumentIOMenuDropdown = () => (
	<Menu.Menu position='right'>
		<Dropdown item text='Аккаунт'>
			<Dropdown.Menu>
				<Dropdown.Item as={Link} to='/dashboard'>Дашборд</Dropdown.Item>
				<Dropdown.Item>Мои карточки</Dropdown.Item>
				<Dropdown.Item>Уведомления</Dropdown.Item>
				<Dropdown.Divider/>
				<Dropdown.Item>Настройки</Dropdown.Item>
			</Dropdown.Menu>
		</Dropdown>
	</Menu.Menu>
)