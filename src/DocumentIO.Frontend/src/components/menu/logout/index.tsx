import React from "react"
import { Dropdown } from 'semantic-ui-react'
import { RouteChildrenProps } from 'react-router'
import { useMutation } from "@apollo/react-hooks"
import { LogoutAccount } from "./mutations"

export const LogoutTemplate = (props: RouteChildrenProps) => {
	const [logout] = useMutation(LogoutAccount)

	const onClick = async () => {
		await logout()
		props.history.push('/login')
	}

	return (
		<Dropdown.Item onClick={onClick}>
			Выйти
		</Dropdown.Item>
	)
}