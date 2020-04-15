export interface IChangeCategoryItemProps {
    Index: number;
    Uid: string;
    ProductUid: string;
    Name: string;
    RemoveFrom: (productUid: string, categoryUid: string) => void;
}