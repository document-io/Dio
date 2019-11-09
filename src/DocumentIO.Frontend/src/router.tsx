import React from 'react'
import { Route, Switch } from 'react-router-dom'

import { HomePage } from './pages/home'
import { LoginPage } from './pages/login'
import { CreatePage } from './pages/create'
import { DashboardPage } from './pages/dashboard'
import { RegisterPage } from './pages/register'

export const Router = () => (
  <Switch>
    <Route exact path='/' component={HomePage}/>
    <Route exact path='/login' component={LoginPage}/>
    <Route exact path='/create' component={CreatePage}/>
    <Route exact path='/dashboard' component={DashboardPage}/>
    <Route exact path='/register/:secret' component={RegisterPage}/>
  </Switch>
)