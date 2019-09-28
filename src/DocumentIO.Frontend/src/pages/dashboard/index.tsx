import React from "react"
import { MenuDropdown, MenuHeader } from "../../components/header"

export const DashboardPage = () => {
	return (
		<React.Fragment>
			<MenuHeader logoUrl='/dashboard'>
				<MenuDropdown />
			</MenuHeader>
			
			<div>Dashboard</div>
		</React.Fragment>
	)
}