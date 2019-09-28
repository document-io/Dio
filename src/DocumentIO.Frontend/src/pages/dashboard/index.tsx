import React from "react"
import { DocumentIOMenu } from "../../components/menu"

export const DashboardPage = () => {
	return (
		<React.Fragment>
			<DocumentIOMenu logoUrl='/dashboard' search dropdown />

			<div>Dashboard</div>
		</React.Fragment>
	)
}