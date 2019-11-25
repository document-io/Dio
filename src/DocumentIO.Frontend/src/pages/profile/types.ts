export interface ReadAccountType {
    login: string
    email: string
    lastName: string
    firstName: string
    middleName: string
    role: string
    organization: {
        id: string
        name: string
    }
    assignments: Array<{
        column: {
            cards: Array<{
                id: string
                name: string
                content: string
                dueDate: string
            }>
        }
    }>
}