export interface ReadBoardType {
    id: string;
    name: string;
    columns: Array<{
        cards: Array<{
            id: string
        }>
    }>
}

export interface CreateBoardType {
    name: string
}