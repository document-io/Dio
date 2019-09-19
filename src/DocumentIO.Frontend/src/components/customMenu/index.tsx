import React, { Component } from 'react'
import { Input, ItemImage, Menu, MenuItemProps } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

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
          as={Link}
          to={'/product'}
          name={'product'}
          active={activeItem === 'product'}
          onClick={this.handleItemClick}
        >
          <ItemImage
            size={'tiny'}
            src={
              'https://icon-library.net/images/bitbucket-icon/bitbucket-icon-10.jpg'
            }
          />
        </Menu.Item>
        <Menu.Menu position="right">
          <Menu.Item>
            <Input icon="search" placeholder="Search..."/>
          </Menu.Item>
          <Menu.Item
            as={Link}
            to={'/login'}
            name="sign_in"
            active={activeItem === 'sign_in'}
            onClick={this.handleItemClick}
          />
          <Menu.Item
            as={Link}
            to={'/registration'}
            name="sign_up"
            active={activeItem === 'sign_up'}
            onClick={this.handleItemClick}
          />
        </Menu.Menu>
      </Menu>
    )
  }
}

export default CustomMenu
