import React, { Component } from 'react'
import { Input, Menu, MenuItemProps } from 'semantic-ui-react'

interface IHeaderState {
  activeItem: string
}

class CustomMenu extends Component<{}, IHeaderState> {
  state = { activeItem: 'home' }

  handleItemClick = (
    e: React.MouseEvent<HTMLAnchorElement>,
    { name }: MenuItemProps
  ) => this.setState({ activeItem: name! })

  render() {
    const { activeItem } = this.state

    return (
      <Menu secondary size={'huge'}>
        <Menu.Item
          name="home"
          active={activeItem === 'home'}
          onClick={this.handleItemClick}
        />
        <Menu.Item
          name="messages"
          active={activeItem === 'messages'}
          onClick={this.handleItemClick}
        />
        <Menu.Item
          name="friends"
          active={activeItem === 'friends'}
          onClick={this.handleItemClick}
        />
        <Menu.Menu position="right">
          <Menu.Item>
            <Input icon="search" placeholder="Search..."/>
          </Menu.Item>
          <Menu.Item
            name="login_in"
            active={activeItem === 'login_in'}
            onClick={this.handleItemClick}
          />
        </Menu.Menu>
      </Menu>
    )
  }
}

export default CustomMenu
