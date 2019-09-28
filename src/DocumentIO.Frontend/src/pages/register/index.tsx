import React from 'react'
import { RouteChildrenProps } from 'react-router'
import { DocumentIOMenu } from "../../components/menu"
import { RegisterPageTemplate } from "./template"

export const RegisterPage = (props: RouteChildrenProps<{secret: string}>) => {
	return (
		<div>
			<DocumentIOMenu logoUrl='/'>
				{/* TODO: */}
			</DocumentIOMenu>

			<RegisterPageTemplate {...props}/>
		</div>
	)
}