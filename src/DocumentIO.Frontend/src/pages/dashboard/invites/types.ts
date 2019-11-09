export interface InviteType {
  description: string
  dueDate: string
  role: string
  secret: string
  account?: {
    id: string
    firstName: string
    lastName: string
  }
}

export interface CreateInviteType {
  description: string
  dueDate: string
  role: string
}

export interface ReadInviteType {
  id: string
  role: string
  dueDate: string
  description: string
  account?: {
    id: string
    firstName: string
    lastName: string
  }
  secret: string
}