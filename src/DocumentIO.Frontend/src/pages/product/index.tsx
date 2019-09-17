import React, { Component } from 'react'
import { Button, Grid, Header, Image } from 'semantic-ui-react'
import { Link } from 'react-router-dom'

class Product extends Component {
  render() {
    return (
      <div>
        <Header as="h1" icon textAlign="center">
          <Header.Content>Built for professional teams</Header.Content>
        </Header>
        <Header as="h3" icon textAlign="center">
          <Header.Content>
            Bitbucket is more than just Git code management. Bitbucket gives
            teams one place to plan <br /> projects, collaborate on code, test,
            and deploy.
          </Header.Content>
        </Header>
        <Header as="h3" icon textAlign="center">
          <Header.Content>
            <Button as={Link} to={'/registration'} primary>
              Get started for free
            </Button>
          </Header.Content>
        </Header>
        <Header as="h4" icon textAlign="center">
          <Header.Content>
            Or host it yourself with
            <Link to={'/product'} className={'component__link'}>
              <a href=""> Bitbucket Enterprise</a>
              <Image
                width={12}
                className={'link-arrow'}
                style={{}}
                src={'https://pixy.org/src/476/4766814.png'}
              />
            </Link>
          </Header.Content>
        </Header>
        <Image
          src={
            'https://wac-cdn.atlassian.com/dam/jcr:10218a75-9e62-445d-b14c-55c8e5ea7aeb/00_HeroImage.png?cdnVersion=557'
          }
          size={'huge'}
          centered
        />
        
        <Grid columns={3} style={{ marginTop: 30 }}>
          <Grid.Row>
            <Grid.Column>
              <Image
                height={150}
                centered
                src={
                  'https://wac-cdn.atlassian.com/dam/jcr:bc1f15f9-3b2e-4c30-9313-0ebd6175f18c/File%20Cabinet@2x.png?cdnVersion=557'
                }
              />
              <Header as="h3" icon textAlign="center">
                <Header.Content>
                  Free unlimited private repositories
                </Header.Content>
              </Header>
              <Header as="h4" icon textAlign="center">
                <Header.Content>
                  Free for small teams under 5 and priced to scale with Standard
                  ($2/user/mo) or Premium ($5/user/mo) plans.
                </Header.Content>
              </Header>
            </Grid.Column>
            <Grid.Column>
              <Image
                height={150}
                centered
                src={
                  'https://wac-cdn.atlassian.com/dam/jcr:cd3efc7d-0600-45f3-b24f-575114db5ce2/integration.png?cdnVersion=557'
                }
              />
              <Header as="h3" icon textAlign="center">
                <Header.Content>
                  Best-in-class Jira & Trello integration
                </Header.Content>
              </Header>
              <Header as="h4" icon textAlign="center">
                <Header.Content>
                  Keep your projects organized by creating Bitbucket branches
                  right from Jira issues or Trello cards.
                </Header.Content>
              </Header>
            </Grid.Column>
            <Grid.Column>
              <Image
                height={150}
                centered
                src={
                  'https://wac-cdn.atlassian.com/dam/jcr:2d6be396-6b47-47b3-b66f-258d933e9df3/continuous-delivery.png?cdnVersion=557'
                }
              />
              <Header as="h3" icon textAlign="center">
                <Header.Content>Built-in Continuous Delivery</Header.Content>
              </Header>
              <Header as="h4" icon textAlign="center">
                <Header.Content>
                  Build, test and deploy with integrated CI/CD. Benefit from
                  configuration as code and fast feedback loops.
                </Header.Content>
              </Header>
            </Grid.Column>
          </Grid.Row>
        </Grid>
      </div>
    )
  }
}

export default Product
