import React from "react";
import {DocumentIOMenu} from "../../components/menu";
import {RouteChildrenProps} from "react-router";
import {Container, Grid, ImageGroup, ItemImage, SegmentGroup, Card} from "semantic-ui-react";
import {useQuery} from "@apollo/react-hooks";
import {ReadProfile, ReadProfileVariables} from "./queries";

export const ProfilePage = (props: RouteChildrenProps) => {
    // @ts-ignore
    const profileId = props.match.params.profileId

    const {data, loading} = useQuery<ReadProfileVariables>(ReadProfile, {
        variables: {
            accountID: profileId
        }
    })

    return loading ? null : (
        <>
            <DocumentIOMenu logoUrl='/' {...props} />
            <Grid centered>
                <Grid.Column>
                    <Container>
                        <SegmentGroup>
                            <Grid>
                                <Grid.Row>
                                    <Grid.Column width={2}/>
                                    <Grid.Column width={6}>
                                        <ItemImage
                                            content={
                                                <img
                                                    src="https://cdn.cnn.com/cnnnext/dam/assets/160725131446-graham-car-crash-evolved-human-full-169.jpeg"
                                                    alt=""/>
                                            }
                                            size="medium"
                                        />
                                    </Grid.Column>
                                    <Grid.Column width={6}>
                                        <Card>
                                            <Card.Content>
                                                <Card.Description>
                                                    <strong>Логин:</strong> {data!.accounts[0].login} <br/>
                                                    <strong>Email:</strong> {data!.accounts[0].email} <br/>
                                                    <strong>Организация:</strong> {data!.accounts[0].organization.name} <br/>
                                                    <strong>Роль:</strong> {data!.accounts[0].role} <br/>
                                                    <strong>Имя:</strong> {data!.accounts[0].firstName} <br/>
                                                    <strong>Фамилия:</strong> {data!.accounts[0].lastName} <br/>
                                                    <strong>Отчество:</strong> {data!.accounts[0].middleName} <br/>
                                                </Card.Description>
                                            </Card.Content>
                                        </Card>
                                    </Grid.Column>
                                </Grid.Row>
                            </Grid>
                        </SegmentGroup>
                        <SegmentGroup>
                            <Card.Group>
                                {data!.accounts[0].assignments.map(({column: {cards}}) => cards.map(({id, name}) =>
                                    <Card key={id} centered>
                                        <Card.Content>
                                            <Card.Header>
                                                {name}
                                            </Card.Header>
                                        </Card.Content>
                                    </Card>
                                ))}
                            </Card.Group>
                        </SegmentGroup>
                    </Container>
                </Grid.Column>
            </Grid>
        </>
    )
}

