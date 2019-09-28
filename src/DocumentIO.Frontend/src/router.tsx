import React from 'react'
import { Switch, Route } from 'react-router-dom'

import { HomePage } from './pages/home'
import { LoginPage } from "./pages/login"
import { CreatePage } from "./pages/create"

export const Router = () => (
	<Switch>
		<Route exact path='/' component={ HomePage }/>
		<Route exact path='/login' component={ LoginPage }/>
		<Route exact path='/create' component={CreatePage }/>
	</Switch>
)