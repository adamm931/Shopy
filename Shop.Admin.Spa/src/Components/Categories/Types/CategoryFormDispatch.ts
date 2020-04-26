export interface CategoryFormDispatch {
    Add: (name: string) => void
    Edit: (uid: string, name: string) => void
}