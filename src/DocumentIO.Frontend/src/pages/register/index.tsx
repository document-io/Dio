import React from 'react'
import { RouteChildrenProps } from 'react-router'
import { MenuHeader } from "../../components/header"
import { RegisterPageTemplate } from "./template"

export const RegisterPage = (props: RouteChildrenProps<{secret: string}>) => {
	return (
		<div>
			<MenuHeader logoUrl='/'>
				{/* TODO: */}
			</MenuHeader>

			<RegisterPageTemplate {...props}/>
		</div>
	)
}