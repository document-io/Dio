import React, {FunctionComponent} from 'react'
import {Button, Grid, Item, Segment} from 'semantic-ui-react'
import {useMutation} from '@apollo/react-hooks'
import dayjs from 'dayjs'
import {ReadInviteType} from '../types'
import {DeleteInvite, DeleteInviteVariables} from './mutations'
import {RouteChildrenProps} from "react-router";

interface InviteProps extends RouteChildrenProps {
    invite: ReadInviteType;
    refresh: () => Promise<void>;
}

export const Invite: FunctionComponent<InviteProps> =
    ({
         invite: {
             id,
             description,
             dueDate,
             role,
             secret,
             account
         },
         refresh,
         history
     }) => {
        const [deleteInvite] = useMutation<string, DeleteInviteVariables>(DeleteInvite)
        const onDeleteInvite = async () => {
            await deleteInvite({
                variables: {
                    inviteId: id
                }
            })
            await refresh()
        }
        const copyInviteUrl = () => {
            navigator.clipboard.writeText(`https://${window.location.host}/register/${secret}`)
        }

        const onProfileView = () => {
            history.push(`/profile/${account!.id}`)
        }

        return (
            <Segment>
                <Grid>
                    <Grid.Row textAlign='left'>
                        <Grid.Column computer={10}>
                            <Item.Group>
                                <Item>
                                    <Item.Content>
                                        <Grid>
                                            <Grid.Row textAlign='left'>
                                                <Grid.Column computer={5}>
                                                    <Item.Header>{account && account.firstName} {account && account.lastName}</Item.Header>
                                                    <Item.Extra>Роль: {role}</Item.Extra>
                                                    <p>Дата
                                                        окончания: {dueDate && dayjs(dueDate).format('DD-MM-YYYY')}</p>
                                                </Grid.Column>
                                                <Grid.Column computer={11}>
                                                    <Item.Description>{description}</Item.Description>
                                                </Grid.Column>
                                            </Grid.Row>
                                        </Grid>
                                    </Item.Content>
                                </Item>
                            </Item.Group>
                        </Grid.Column>
                        <Grid.Column computer={6}>
                            {!account && (
                                <>
                                    <Button basic color='black' onClick={copyInviteUrl}>Copy invite</Button>
                                    <Button basic color='black' onClick={onDeleteInvite}>Delete invite</Button>
                                </>
                            )}
                            {account && <Button basic color='black' onClick={onProfileView}>Profile</Button>}
                        </Grid.Column>
                    </Grid.Row>
                </Grid>
            </Segment>
        )
    }
