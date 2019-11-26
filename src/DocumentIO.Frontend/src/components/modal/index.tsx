import React, { useState } from 'react'
import { Button, Dimmer, Icon, Loader, Modal } from 'semantic-ui-react'
import { useMutation, useQuery } from '@apollo/react-hooks'
import { ReadCard, ReadCardVariables } from './queries'
import { Editor } from '../editor'
import { UpdateCard, UpdateCardVariables } from '../../pages/board/mutations'

export const CardModal =
  ({
     cardId, onCard
   }: {
    cardId: string, onCard: (cardId: string) => void
  }) => {
    const { data, loading, refetch } = useQuery<ReadCardVariables>(ReadCard, {
      variables: {
        cardId
      }
    })
    console.log(cardId)
    const [updateCard] = useMutation<{}, UpdateCardVariables>(UpdateCard)

    const [content, setContent] = useState(data === undefined ? '' : data!.cards[0].content)

    if (loading) {
      return (
        <Dimmer active inverted>
          <Loader size='big'/>
        </Dimmer>
      )
    }
    const card = data!.cards[0]

    const cardUpdate = async () => {
      try {
        await updateCard({
          variables: {
            card: {
              content,
              id: cardId
            }
          }
        })
      } catch (e) {

      }
    }

    return (
      <Modal open={cardId !== ''} onClose={() => onCard('')}>
        <Modal.Header>{card.name}</Modal.Header>
        <Modal.Content image scrolling>
          <Editor setContent={setContent} content={content}/>
        </Modal.Content>
        <Modal.Actions>
          <Button primary onClick={cardUpdate}>
            Proceed <Icon name='chevron right'/>
          </Button>
        </Modal.Actions>
      </Modal>
    )
  }