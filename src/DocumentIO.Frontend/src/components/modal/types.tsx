export interface ReadCardType {
  name: string
  content: string
  description: string
  dueDate: string
  createdAt: string
  assignments: Array<{
    firstName: string
    lastName: string
  }>
  comments: {
    id: string
    text: string
    account: {
      firstName: string
      lastName: string
    }
  }
}