import React from 'react'
import './App.scss'
import CustomMenu from './components/customMenu'
import { Container } from 'semantic-ui-react'
import { Redirect, Route, Switch } from 'react-router-dom'
import Login from './pages/login'
import Product from './pages/product'

const App: React.FC = () => {
  return (
    <Switch>
      <Container>
        <CustomMenu/>
        <Route exact path="/login" render={(props) => <Login {...props} />}/>
        <Route
          exact
          path="/product"
          render={(props) => <Product {...props} />}
        />
        <Redirect to="/product"/>
      </Container>
    </Switch>
  )
}

export default App
