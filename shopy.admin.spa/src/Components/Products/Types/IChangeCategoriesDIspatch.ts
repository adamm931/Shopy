export interface IChangeCategoriesDispatch {
    RemoveFrom: (productUid: string, categoryUid: string) => void
    AddTo: (productUid: string, categoryUid: string) => void
    CategoriesLookup: () => void
    GetProductCategories: () => void
}