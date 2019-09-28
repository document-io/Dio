import React, { PropsWithChildren } from 'react'
import { Menu, Dropdown, Header } from "semantic-ui-react"
import { Link } from 'react-router-dom'
import { DocumentIOMenuDropdown } from "./dropdown"
import { DocumentIOSearch } from "./search"

export interface Props extends PropsWithChildren<{}>{
	logoUrl: string
	dropdown?: boolean
	search?: boolean
}

export const DocumentIOMenu = (props: Props) => {

	return (
		<Menu size='small' borderless fluid>
			<Menu.Item>
				<Header as={Link} to={props.logoUrl}>
					DocumentIO
				</Header>
			</Menu.Item>

			{
				props.search
					? (
						<Menu.Item style={{flexGrow: 1}}>
							<DocumentIOSearch/>
						</Menu.Item>)
					: null
			}

			<Menu.Menu position='right'>
				{
					props.dropdown
						? <DocumentIOMenuDropdown />
						: props.children
				}
			</Menu.Menu>
		</Menu>
	)
}