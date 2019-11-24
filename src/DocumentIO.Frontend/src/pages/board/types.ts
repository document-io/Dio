export interface CreateColumnType {
  boardId: string
  name: string
}

export interface CreateCardType {
  columnId: string
  name: string
}

export interface ReadColumns {
  id: string
  name: string
  cards: Array<{
    id: string
    name: string
    content: string
  }>
}