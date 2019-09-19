import React, { Component } from 'react'
import { Button, Form } from 'semantic-ui-react'

class Login extends Component {
  render() {
    return (
      <div className={'login-form'}>
        <Form>
          <Form.Field>
            <label>Email</label>
            <input placeholder="Email" />
          </Form.Field>
          <Form.Field>
            <label>Password</label>
            <input placeholder="Password" />
          </Form.Field>
          <Button type="submit">Submit</Button>
        </Form>
      </div>
    )
  }
}

export default Login
